using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using Indt.Sistema.Seguros.Domain.Adapters.Dispatchers;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;
using Serilog;

namespace Indt.Sistema.Seguros.App.Workers.CriarContrato
{
    public class CriarContratoDispatcher : ICriarContratoDispatcher
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly IPropostaRepository _propostaRepository;
        private readonly INotification _notificacao;
        private readonly ILogger _logger;

        public CriarContratoDispatcher(IContratoRepository contratoRepository, INotification notificacao, ILogger logger, IPropostaRepository propostaRepository)
        {
            _contratoRepository = contratoRepository;
            _notificacao = notificacao;
            _logger = logger;
            _propostaRepository = propostaRepository;
        }

        public async Task CriarContratoAsync(ContratoCriadoCommand contratoCriadoCommand, CancellationToken cancellationToken = default)
        {
            var contrato = new Contrato
            (
                contratoCriadoCommand.Numero,
                contratoCriadoCommand.DataInicial,
                contratoCriadoCommand.DataFinal,
                contratoCriadoCommand.NumeroPorposta,
                contratoCriadoCommand.Valor,
                contratoCriadoCommand.Prazo
            );

            var valorParcela = contrato.CalcularValorParcela(contrato.Valor, contrato.Prazo);
            contrato.GerarParcelas(valorParcela, contrato.Prazo);

            var proposta = await _propostaRepository.ObterPorNumeroAsync(contrato.NumeroPorposta, cancellationToken);

            if (proposta == null)
            {
                var mensagem = "Proposta não econtrada";
                var mensagemTemplate = $"CriarContratoDispatcher | CriarContratoAsync | Mensagem : {mensagem}";
                _logger.Warning(mensagemTemplate);
                _notificacao.AddNotificacao("PROPOSTA_NAOENCONTRADA", mensagem);
                return;
            }

            await _contratoRepository.CriarAsync(contrato, proposta.Id.Value, cancellationToken);
        }
    }
}
