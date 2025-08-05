using Indt.Sistema.Seguros.Domain.Adapters.Commands;

namespace Indt.Sistema.Seguros.Domain.Adapters.Producers
{
    public interface IContratoCriadoProducer
    {
        Task CriarContrato(ContratoCriadoCommand mensagem);
    }
}
