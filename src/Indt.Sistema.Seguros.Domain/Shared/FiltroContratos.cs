namespace Indt.Sistema.Seguros.Domain.Shared
{
    public class FiltroContratos
    {
        public int Numero { get; set; }

        public DateTimeOffset DataInicial { get; set; }

        public DateTimeOffset DataFim { get; set; }

        public int Pagina { get; set; }

        public int ItensPorPagina { get; set; }
    }
}
