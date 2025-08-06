using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using Indt.Sistema.Seguros.Domain.Adapters.Dispatchers;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
using Serilog;

namespace Indt.Sistema.Seguros.App.Workers.CriarContrato
{
    public class CriarContratoDispatcher : ICriarContratoDispatcher
    {
        private readonly IContratoRepository _contratoRepository;        
        private readonly ILogger _logger;

        public CriarContratoDispatcher(IContratoRepository contratoRepository, ILogger logger)
        {
            _contratoRepository = contratoRepository;            
            _logger = logger;            
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

            await _contratoRepository.CriarAsync(contrato, contratoCriadoCommand.PropostaId, cancellationToken);

            var mensagemContratoCriado = $"CriarContratoDispatcher | CriarContratoAsync | Mensagem : Contrato criado {contrato.Id}";
            _logger.Information(mensagemContratoCriado);
        }
    }
}
