using Indt.Sistema.Seguros.Domain.Models.Models.Shared;

namespace Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate
{
    public class Contrato : CoreEntity
    {
        public int Numero { get; init; }

        public DateTime DataInicial { get; init; }

        public DateTime DataFinal { get; init; }

        public int NumeroPorposta { get; init; }

        public decimal Valor { get; init; }

        public int Prazo { get; init; }

        public int NumeroProposta { get; init; }

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
                Parcelas.Add(new Parcela(valor,DateTime.Now.AddDays(i * 30),i));
            }
        }

    }
}
