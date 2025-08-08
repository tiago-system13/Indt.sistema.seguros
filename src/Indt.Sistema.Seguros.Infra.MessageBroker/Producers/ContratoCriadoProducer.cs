using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using Indt.Sistema.Seguros.Domain.Adapters.Producers;
using MassTransit;

namespace Indt.Sistema.Seguros.Infra.MessageBroker.Producers
{
    public class ContratoCriadoProducer : IContratoCriadoProducer
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public ContratoCriadoProducer(ISendEndpointProvider sendEndpointProvider) {

            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task CriarContrato(ContratoCriadoCommand mensagem)
        {
                 await _sendEndpointProvider.Send(mensagem);
        }
    }
}
