using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using MediatR;

namespace Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta
{
    public class AlterarStatusPropostaRequest : RequestDto, IRequest<AlterarStatusPropostaResponse>
    {
        public StatusProposta StatusProposta { get; set; }

        public Guid PropostaId { get; set; }

    }
}
