using Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate;
using Indt.Sistema.Seguros.Domain.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;

namespace Indt.Sistema.Seguros.Domain.Adapters.Repository
{
    public interface IPropostaRepository
    {
        ValueTask<Guid> CriarAsync(Proposta proposta, CancellationToken cancellationToken = default);

        ValueTask AtualizarAsync(Proposta proposta, CancellationToken cancellationToken = default);

        ValueTask AtualizarStatusProposta(StatusProposta statusProposta, Guid id, CancellationToken cancellationToken = default);

        ValueTask<Proposta> ObterPorNumeroAsync(int numero, CancellationToken cancellationToken = default);

        ValueTask<Proposta> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);

        ValueTask<List<Proposta>> ListarAsync(FiltroPropostas filtroPropostas, CancellationToken cancellationToken = default);
    }
}
