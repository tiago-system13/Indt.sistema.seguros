using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indt.Sistema.Seguros.Infra.MessageBroker.Consumers
{
    public class ContratoCriadoConsumer : IConsumer<ContratoCriadoCommand>
    {
        public Task Consume(ConsumeContext<ContratoCriadoCommand> context)
        {
            throw new NotImplementedException();
        }
    }
}
