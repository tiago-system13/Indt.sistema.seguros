using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta
{
    public class AlterarStatusPropostaRequest : RequestDto, IRequest<AlterarStatusPropostaResponse>
    {
        /// <summary>
        /// Status da proposta :  0 = Cadastrada, 1 = Analise, 2 = Aprovada , 3 = Cancelada,  4 = Reprovada , 5 Pendente
        /// </summary>
        [SwaggerSchema(Description = "Status da Proposta")]
        public StatusProposta StatusProposta { get; set; }

        [SwaggerSchema(Description = "Id da Proposta")]
        public Guid PropostaId { get; set; }

    }
}
