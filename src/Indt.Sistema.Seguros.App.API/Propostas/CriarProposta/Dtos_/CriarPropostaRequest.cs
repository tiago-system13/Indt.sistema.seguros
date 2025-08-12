using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Indt.Sistema.Seguros.App.API.Propostas.CriarProposta
{
    public class CriarPropostaRequest : RequestDto, IRequest<CriarPropostaResponse>
    {
        /// <summary>
        /// Número da proposta
        /// </summary>
        [SwaggerSchema(Description = "Número Proposta")]
        public int Numero { get; set; }

        /// <summary>
        /// Tipo de Seguro: 0 - Novo , 1 = Renovação
        /// </summary>
        [SwaggerSchema(Description = "Tipo de Seguro")]
        public TipoSeguro TipoSeguro { get; set; }

        public DateTimeOffset DataInicio { get; set; }

        public DateTimeOffset DataFim { get; set; }      

        public decimal Valor { get;  set; }        

        public ClienteDto Cliente { get;  set; }

        public BemMovelDto BemMovel { get; set; }

        public CoberturaDto Cobertura { get; set; }
    }
}
