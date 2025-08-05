namespace Indt.Sistema.Seguros.Infra.DataBase.Models.ContratoAgreggate
{
    public class ParcelaEntity
    {
        public Guid Id { get; set; }
        public DateTime DataDeCriacao { get; private set; } 
        public DateTime? DataDeAlteracao { get; private set; }
        public decimal Valor { get; private set; } 
        public DateTime Data { get; private set; } 
        public int Numero { get; private set; } 
        public virtual ContratoEntity ContratoEntity { get; private set; } 
        public Guid ContratoId { get; private set; }

        public ParcelaEntity(Guid id, DateTime dataDeCriacao, DateTime? dataDeAlteracao, decimal valor, DateTime data, int numero, Guid contratoId)
        {
            Id = id;
            DataDeCriacao = dataDeCriacao;
            DataDeAlteracao = dataDeAlteracao;
            Valor = valor;
            Data = data;
            Numero = numero;
            ContratoId = contratoId;
        }
    }
}
