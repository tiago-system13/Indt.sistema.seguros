using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Shared;

namespace Indt.Sistema.Seguros.App.API.Contratos.ListarContratos
{
    public class ListarContratosHandler : IHandler<ListarContratosRequest, ListarContratosResponse>
    {
        private readonly IContratoRepository _contratoRepository;

        public ListarContratosHandler(IContratoRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        public async Task<ListarContratosResponse> Handle(ListarContratosRequest request, CancellationToken cancellationToken)
        {
            var filtroContrato = new FiltroContratos()
            {
                Numero = request.Numero,
                DataFim = request.DataFim,
                DataInicial = request.DataInicial,
                ItensPorPagina = request.ItensPorPagina,
                Pagina = request.Pagina,                
            };

            var contratos = await _contratoRepository.ListarAsync(filtroContrato, cancellationToken);

            return new ListarContratosResponse()
            {
                Contratos = contratos.Item1.Select(x => ContratosMapper.Map(x)).ToList(),
                TotalPaginas = Math.Ceiling(contratos.TotalContratos / (decimal)request.ItensPorPagina),
                TotalContratos = contratos.TotalContratos,
                Sucesso = true
            };
        }
    }
}
