using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using Indt.Sistema.Seguros.Domain.Adapters.Dispatchers;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks;
using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
using Serilog;

namespace Indt.Sistema.Seguros.App.Workers.CriarContrato
{
    public class CriarContratoDispatcher : ICriarContratoDispatcher
    {
        private readonly IContratoRepository _contratoRepository;        
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CriarContratoDispatcher(IContratoRepository contratoRepository, IUnitOfWork unitOfWork)
        {
            _contratoRepository = contratoRepository;
            _logger = Log.ForContext<CriarContratoDispatcher>();            
            _unitOfWork = unitOfWork;
        }

        public async Task CriarContratoAsync(ContratoCriadoCommand contratoCriadoCommand, CancellationToken cancellationToken = default)
        {
            var mensagemTemplate = $"CriarContratoDispatcher | CriarContratoAsync | Mensagem : {contratoCriadoCommand}";
            _logger.Information(mensagemTemplate);

            var contrato = new Contrato
            (
                contratoCriadoCommand.Numero,
                contratoCriadoCommand.DataInicial,
                contratoCriadoCommand.DataFinal,
                contratoCriadoCommand.PropostaId,
                contratoCriadoCommand.Valor,
                contratoCriadoCommand.Prazo
            );

            var valorParcela = contrato.CalcularValorParcela(contrato.Valor, contrato.Prazo);
            contrato.GerarParcelas(valorParcela, contrato.Prazo);            

            await _unitOfWork.BeginTransaction();
            await _contratoRepository.CriarAsync(contrato, contratoCriadoCommand.PropostaId, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransaction();
            var mensagemContratoCriado = $"CriarContratoDispatcher | CriarContratoAsync | Mensagem : Contrato criado {contrato.Id}";
            _logger.Information(mensagemContratoCriado);
        }
    }
}
