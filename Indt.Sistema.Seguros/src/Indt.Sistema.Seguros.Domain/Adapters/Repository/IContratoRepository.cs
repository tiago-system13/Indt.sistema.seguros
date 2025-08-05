using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;

namespace Indt.Sistema.Seguros.Domain.Adapters.Repository
{
    public interface IContratoRepository
    {
        ValueTask<Guid> CriarAsync(Contrato contrato, Guid propostaId, CancellationToken cancellationToken = default);

        ValueTask<Contrato> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
