namespace Indt.Sistema.Seguros.App.API.Contratos.ListarContratos
{
    public class ContratoDto
    {
        public int Numero { get; set; }

        public DateTimeOffset DataInicio { get; set; }

        public DateTimeOffset DataFim { get; set; }

        public decimal Valor { get; set; }

        public int Prazo { get; set; }

        public Guid PropostaId { get; set; }

        public List<ParcelaDto> Parcelas { get; set; }
    }
}
