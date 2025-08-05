using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using MediatR;

namespace Indt.Sistema.Seguros.App.API.Propostas.CriarProposta
{
    public class CriarPropostaRequest : RequestDto, IRequest<CriarPropostaResponse>
    {
        public int Numero { get; init; }

        public TipoSeguro TipoSeguro { get; init; }

        public DateTimeOffset DataInicio { get; init; }

        public DateTimeOffset DataFim { get; init; }

        public StatusProposta StatusProposta { get; private set; }

        public decimal Valor { get; private set; }

        public int Prazo { get; private set; }

        public ClienteDto Cliente { get; private set; }

        public BemMovelDto BemMovel { get; private set; }

        public CoberturaDto Cobertura { get; private set; }
    }
}
