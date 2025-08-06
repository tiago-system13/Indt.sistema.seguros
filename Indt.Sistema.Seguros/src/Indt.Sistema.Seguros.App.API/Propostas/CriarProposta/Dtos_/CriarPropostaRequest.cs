using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using MediatR;

namespace Indt.Sistema.Seguros.App.API.Propostas.CriarProposta
{
    public class CriarPropostaRequest : RequestDto, IRequest<CriarPropostaResponse>
    {
        public int Numero { get; set; }

        public TipoSeguro TipoSeguro { get; set; }

        public DateTimeOffset DataInicio { get; set; }

        public DateTimeOffset DataFim { get; set; }      

        public decimal Valor { get; private set; }

        public int Prazo { get; private set; }

        public ClienteDto Cliente { get;  set; }

        public BemMovelDto BemMovel { get; set; }

        public CoberturaDto Cobertura { get; set; }
    }
}
