using Indt.Sistema.Seguros.Domain.Adapters.Commands;

namespace Indt.Sistema.Seguros.Domain.Adapters.Dispatchers
{
    public interface ICriarContratoDispatcher
    {
        Task CriarContratoAsync(ContratoCriadoCommand contratoCriadoCommand, CancellationToken cancellationToken = default);
    }
}
