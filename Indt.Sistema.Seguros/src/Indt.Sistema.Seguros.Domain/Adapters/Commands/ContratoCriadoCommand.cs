namespace Indt.Sistema.Seguros.Domain.Adapters.Commands
{
    public class ContratoCriadoCommand
    {
        public int Numero { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public int NumeroPorposta { get; set; }

        public decimal Valor { get; set; }

        public int Prazo { get; set; }

        public int NumeroProposta { get; set; }        
    }
}
