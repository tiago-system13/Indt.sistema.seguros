using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using MediatR;

namespace Indt.Sistema.Seguros.App.API.Propostas.ListarPropostas
{
    public class ListarPropostasRequest : RequestDto, IRequest<ListarPropostasResponse>
    {
        public int Numero { get; set; }

        public StatusProposta? StatusProposta { get; set; }

        public DateTimeOffset DataInicial { get; set; }

        public DateTimeOffset DataFim { get; set; }

        public int Pagina { get; set; }

        public int ItensPorPagina { get; set; }
    }
}
