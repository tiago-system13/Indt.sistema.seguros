using Indt.Sistema.Seguros.App.API.Shared;
using MediatR;

namespace Indt.Sistema.Seguros.App.API.Contratos.ListarContratos
{
    public class ListarContratosRequest : RequestDto, IRequest<ListarContratosResponse>
    {
        public int Numero { get; set; }

        public DateTimeOffset DataInicial { get; set; }

        public DateTimeOffset DataFim { get; set; }

        public int Pagina { get; set; }

        public int ItensPorPagina { get; set; }
    }
}
