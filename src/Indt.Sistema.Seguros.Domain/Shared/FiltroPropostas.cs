using Indt.Sistema.Seguros.Domain.Shared.Enums;

namespace Indt.Sistema.Seguros.Domain.Shared
{
    public class FiltroPropostas
    {
        public int Numero { get; set; }

        public StatusProposta? StatusProposta { get; set; }

        public DateTimeOffset DataInicial { get; set; }

        public DateTimeOffset DataFim { get; set; }

        public int Pagina { get; set; }

        public int ItensPorPagina { get; set; }
    }
}
