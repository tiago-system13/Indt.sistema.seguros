using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;

namespace Indt.Sistema.Seguros.App.API.Contratos.ListarContratos
{
    public static class ContratosMapper
    {
        public static ContratoDto Map(Contrato contrato)
        {
            return new ContratoDto()
            {               
                DataInicio = contrato.DataInicial,
                DataFim = contrato.DataFinal,
                Valor = contrato.Valor,
                Prazo = contrato.Prazo,
                Numero = contrato.Numero,
                PropostaId = contrato.PropostaId,
                Parcelas = contrato.Parcelas.Select(x=> Map(x)).ToList()
            };

        }

        public static ParcelaDto Map(Parcela parcela)
        {
            return new ParcelaDto()
            {
                Data = parcela.Data,
                Valor = parcela.Valor,
                Numero = parcela.Numero
            };
        }
    }
}
