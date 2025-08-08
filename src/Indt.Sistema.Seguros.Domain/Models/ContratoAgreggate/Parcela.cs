using Indt.Sistema.Seguros.Domain.Models.Models.Shared;

namespace Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate
{
    public class Parcela(decimal valor, DateTime data, int numero) : CoreEntity
    {
        public decimal Valor { get; private set; } = valor;
        public DateTime Data { get; private set; } = data;
        public int Numero { get; private set; } = numero;
    }
}
