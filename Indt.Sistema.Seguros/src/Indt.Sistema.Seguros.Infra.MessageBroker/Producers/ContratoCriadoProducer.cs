using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using Indt.Sistema.Seguros.Domain.Adapters.Producers;
using MassTransit;

namespace Indt.Sistema.Seguros.Infra.MessageBroker.Producers
{
    public class ContratoCriadoProducer : IContratoCriadoProducer
    {
        private readonly IBusControl _bus;

        public ContratoCriadoProducer(IBusControl bus)
        {
            _bus = bus;
        }

        public Task CriarContrato(ContratoCriadoCommand mensagem)
        {
            return _bus.Send(mensagem);
        }
    }
}
