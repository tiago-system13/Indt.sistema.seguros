using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Shared;

namespace Indt.Sistema.Seguros.App.API.Propostas.ListarPropostas
{
    public class ListarPropostasHandler : IHandler<ListarPropostasRequest, ListarPropostasResponse>
    {
        private readonly IPropostaRepository _propostaRepository;

        public ListarPropostasHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public async Task<ListarPropostasResponse> Handle(ListarPropostasRequest request, CancellationToken cancellationToken)
        {
            var filtroProposta = new FiltroPropostas()
            {
                Numero = request.Numero,
                DataFim = request.DataFim,
                DataInicial = request.DataInicial,
                ItensPorPagina = request.ItensPorPagina,
                Pagina = request.Pagina,
                StatusProposta = request.StatusProposta
            };

            var propostas = await _propostaRepository.ListarAsync(filtroProposta, cancellationToken);

            return new ListarPropostasResponse()
            {
                Propostas = propostas.Item1.Select(x => PropostaMapper.Map(x)).ToList(),
                TotalPagina = Math.Ceiling(propostas.TotalProposta / (decimal)request.ItensPorPagina),
                TotalPropostas = propostas.TotalProposta
            };
        }
    }
}
