using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
using Indt.Sistema.Seguros.Domain.Models.Models.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;

namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class Proposta : CoreEntity
    {
        public int Numero { get; init; }

        public TipoSeguro TipoSeguro { get; init; }

        public DateTimeOffset DataInicio { get; init; }

        public DateTimeOffset DataFim { get; init; }

        public StatusProposta StatusProposta { get; private set; }

        public decimal Valor { get; private set; }

        public int Prazo { get; private set; }

        public Cliente Cliente { get; private set; }

        public Bem Bem { get; private set; }

        public Cobertura Cobertura { get; private set; }
        
        public Proposta
        (
            int numero,
            DateTimeOffset dataInicio,
            DateTimeOffset dataFim,
            StatusProposta statusProposta,
            TipoSeguro tipoSeguro,
            decimal valor,
            int prazo,
            Cliente cliente,
            Bem bem,
            Cobertura cobertura,
            Guid? id = null)
        {
            Numero = numero;
            DataInicio = dataInicio;
            DataFim = dataFim;
            TipoSeguro = tipoSeguro;
            StatusProposta = statusProposta;
            Valor = valor;
            Prazo = prazo;            
            Cliente = cliente;
            Bem = bem;
            Cobertura = cobertura;
            Id = id;
            Validate(this, new PropostaValidator());
            
        }        

        public void AlterarStatusProposta(StatusProposta statusProposta, DateTime dataAtualizacao)
        {
            StatusProposta = statusProposta; 
            DataDeAlteracao = dataAtualizacao;
        }

        public void SetarPrazoProposta(DateTimeOffset dataInicio, DateTimeOffset dataFim)
        {
            Prazo = ((dataFim.Year - dataInicio.Year) * 12) + dataFim.Month - dataInicio.Month;
        }
    }
}
