using Indt.Sistema.Seguros.Domain.Adapters;
using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
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

        public ContratoRepository(SegurosContext context, INotification notificacao, ILogger logger)
        {
            _context = context;
            _notificacao = notificacao;
            _logger = logger;
        }

        public async ValueTask<Guid> CriarAsync(Contrato contrato, Guid propostaId, CancellationToken cancellationToken = default)
        {           
            var contratoEntity = MapaerContratoEntity(contrato, propostaId);
            contratoEntity.CriarParcelas(contrato.Parcelas, contratoEntity.Id);
            await _context.Contratos.AddAsync(contratoEntity, cancellationToken);
            return contratoEntity.Id;
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
            return new Contrato
            (
                contratoEntity.Numero,
                contratoEntity.DataInicial,
                contratoEntity.DataFinal,
                contratoEntity.Proposta.Numero,
                contratoEntity.Valor,
                contratoEntity.Prazo
            );
        }
    }
}
