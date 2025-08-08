using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
using Indt.Sistema.Seguros.Infra.DataBase.Models.PropostaAgreggate;

namespace Indt.Sistema.Seguros.Infra.DataBase.Models.ContratoAgreggate
{
    public class ContratoEntity
    {
        public Guid Id { get; private set; } 

        public DateTime DataDeCriacao { get; private set; } 

        public DateTime? DataDeAlteracao { get; private set; } 
        public int Numero { get; private set; } 

        public Guid PropostaId { get; private set; } 

        public DateTimeOffset DataInicial { get; private set; } 

        public DateTimeOffset DataFinal { get; private set; } 

        public decimal Valor { get; private set; } 

        public int Prazo { get; private set; } 

        public virtual PropostaEntity Proposta { get; set; }

        public virtual List<ParcelaEntity> Parcelas { get; private set; } = new List<ParcelaEntity>();

        public ContratoEntity(Guid id, DateTime dataDeCriacao,int numero, Guid propostaId, DateTimeOffset dataInicial, DateTimeOffset dataFinal, decimal valor, int prazo)
        {
            Id = id;
            DataDeCriacao = dataDeCriacao;       
            Numero = numero;
            PropostaId = propostaId;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Valor = valor;
            Prazo = prazo;
        }

        public void CriarParcelas(List<Parcela> parcelas)
        {
            foreach (var parcela in parcelas)
            {
                Parcelas.Add(new ParcelaEntity(parcela.Id.Value, parcela.DataDeCriacao, null, parcela.Valor, parcela.Data, parcela.Numero, Id));
            }
           
        }
    }
}
