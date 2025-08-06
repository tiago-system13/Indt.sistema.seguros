using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using Indt.Sistema.Seguros.Domain.Adapters.Dispatchers;
using MassTransit;

namespace Indt.Sistema.Seguros.Infra.MessageBroker.Consumers
{
    public class ContratoCriadoConsumer : IConsumer<ContratoCriadoCommand>
    {
        private readonly ICriarContratoDispatcher _criarContratoDispatcher;

        public ContratoCriadoConsumer(ICriarContratoDispatcher criarContratoDispatcher)
        {
            _criarContratoDispatcher = criarContratoDispatcher;
        }

        public async Task Consume(ConsumeContext<ContratoCriadoCommand> context)
        {
            await _criarContratoDispatcher.CriarContratoAsync(context?.Message);
        }
    }
}
