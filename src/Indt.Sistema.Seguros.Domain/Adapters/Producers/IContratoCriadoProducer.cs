using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using MassTransit;

namespace Indt.Sistema.Seguros.Domain.Adapters.Producers
{
    public interface IContratoCriadoProducer
    {
        Task CriarContrato(ContratoCriadoCommand mensagem);
    }
}
