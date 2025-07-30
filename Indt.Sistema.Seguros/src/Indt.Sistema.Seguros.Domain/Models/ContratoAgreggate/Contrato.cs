namespace Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate
{
    public class Contrato
    {
        public int Numero { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public int NumeroPorposta { get; set; }

        public decimal Valor { get; set; }

        public int Prazo { get; set; }

        public List<Parcela> Parcelas { get; private set; }

        public  Contrato()
        {
            Parcelas = new List<Parcela>();
        }

        public Contrato(int numero, DateTime dataInicial, DateTime dataFinal, int numeroPorposta, decimal valor, int prazo)
        {
            Numero = numero;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            NumeroPorposta = numeroPorposta;
            Valor = valor;
            Prazo = prazo;
        }

        public decimal CalcularValorParcela(decimal valor, int prazo)
        {
            if (prazo == 0) throw new DivideByZeroException("Não é possível divisão por zero");

            return valor / prazo;
        }

        public void GerarParcelas(decimal valor, int prazo)
        {
            for (int i = 1; i <= prazo; i++)
            {
                Parcelas.Add(new Parcela { Valor = valor, Data = DateTime.Now.AddDays(i * 30), Numero = i });
            }
        }

    }
}
