namespace Indt.Sistema.Seguros.Domain.Adapters.Commands
{
    public class ContratoCriadoCommand
    {
        public int Numero { get; set; }

        public DateTimeOffset DataInicial { get; set; }

        public DateTimeOffset DataFinal { get; set; }        

        public decimal Valor { get; set; }

        public int Prazo { get; set; }

        public Guid PropostaId { get; set; }        
    }
}
