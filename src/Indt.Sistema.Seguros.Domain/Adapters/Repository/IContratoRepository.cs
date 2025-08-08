using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
using Indt.Sistema.Seguros.Domain.Shared;

namespace Indt.Sistema.Seguros.Domain.Adapters.Repository
{
    public interface IContratoRepository
    {
        ValueTask<Guid> CriarAsync(Contrato contrato, Guid propostaId, CancellationToken cancellationToken = default);

        ValueTask<Contrato> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);

        ValueTask<(List<Contrato> Contratos, int TotalContratos)> ListarAsync(FiltroContratos filtroContratos, CancellationToken cancellationToken = default);
    }
}
