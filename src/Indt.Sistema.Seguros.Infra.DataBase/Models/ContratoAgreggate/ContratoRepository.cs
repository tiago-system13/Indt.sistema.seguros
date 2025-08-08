using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
using Indt.Sistema.Seguros.Domain.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;
using Indt.Sistema.Seguros.Infra.DataBase.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Indt.Sistema.Seguros.Infra.DataBase.Models.ContratoAgreggate
{
    internal class ContratoRepository : IContratoRepository
    {
        private readonly SegurosContext _context;
        private readonly INotification _notificacao;
        private readonly ILogger _logger;

        public ContratoRepository(SegurosContext context, INotification notificacao)
        {
            _context = context;
            _notificacao = notificacao;
            _logger = Log.ForContext<ContratoRepository>();
        }

        public async ValueTask<Guid> CriarAsync(Contrato contrato, Guid propostaId, CancellationToken cancellationToken = default)
        {           
            var contratoEntity = MapaerContratoEntity(contrato, propostaId);
            contratoEntity.CriarParcelas(contrato.Parcelas);
            await _context.Contratos.AddAsync(contratoEntity, cancellationToken);
            return contratoEntity.Id;
        }

        public async ValueTask<(List<Contrato> Contratos, int TotalContratos)> ListarAsync(FiltroContratos filtroContratos, CancellationToken cancellationToken = default)
        {
            var query = _context.Contratos
                        .Include(x=> x.Parcelas)
                        .Include(x=> x.Proposta).AsNoTracking();


            if (filtroContratos.DataInicial != DateTimeOffset.MinValue && filtroContratos.DataFim != DateTimeOffset.MinValue)
                query = query.Where(x => filtroContratos.DataInicial >= x.DataDeCriacao && x.DataDeCriacao <= filtroContratos.DataFim);

            if (filtroContratos.Numero > 0)
                query = query.Where(x => x.Numero == filtroContratos.Numero);

            var totalContratos = query.Count();

            query = query.Skip((filtroContratos.Pagina - 1) * filtroContratos.ItensPorPagina).Take(filtroContratos.ItensPorPagina);

            var contratos = await query.ToListAsync(cancellationToken);

            return (contratos.Select(x => MapearContrato(x)).ToList(), totalContratos);
        }

        public async ValueTask<Contrato> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var contratoEntity = await _context.Contratos.Include(x=> x.Proposta)
                                                         .Include(x=>x.Parcelas)
                                                         .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (contratoEntity == null)
            {
                var mensagem = "Contrato não encontrado";
                var mensagemTemplate = $"ContratoRepository | Obter | Mensagem : {mensagem}";
                _logger.Warning(mensagemTemplate);
                _notificacao.AddNotificacao("CONTRATO_NAOENCONTRADO", mensagem);
                return default;
            }

            return MapearContrato(contratoEntity);
        }

        private ContratoEntity MapaerContratoEntity(Contrato contrato, Guid propostaId)
        {
            return new ContratoEntity(contrato.Id.Value, contrato.DataDeCriacao, contrato.Numero, propostaId, contrato.DataInicial,contrato.DataFinal, contrato.Valor, contrato.Prazo);
        }

        private Contrato MapearContrato(ContratoEntity contratoEntity)
        {
            var contrato = new Contrato
            (
                contratoEntity.Numero,
                contratoEntity.DataInicial,
                contratoEntity.DataFinal,
                contratoEntity.Proposta.Id.Value,
                contratoEntity.Valor,
                contratoEntity.Prazo
            );

            contrato.SetParcelas(contratoEntity.Parcelas.Select(x => new Parcela(x.Valor, x.Data, x.Numero)).ToList());

            return contrato;

        }
    }
}
