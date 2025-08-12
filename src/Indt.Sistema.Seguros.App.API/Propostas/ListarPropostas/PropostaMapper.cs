using Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate;

namespace Indt.Sistema.Seguros.App.API.Propostas.ListarPropostas
{
    public static class PropostaMapper
    {
        public static PropostasDto Map(Proposta proposta)
        {
            return new PropostasDto()
            {
                PropostaId = proposta.Id.Value,
                TipoSeguro = proposta.TipoSeguro,
                DataInicio = proposta.DataInicio,
                DataFim = proposta.DataFim,
                Valor = proposta.Valor,
                Prazo = proposta.Prazo,
                Numero = proposta.Numero,
                StatusProposta = proposta.StatusProposta,
                ContatoClinete = $"({proposta.Cliente.Contato.Ddd}) {proposta.Cliente.Contato.Numero}",
                NomeCliente = proposta.Cliente.Nome,
                DocumentoCliente = proposta.Cliente.Documento,
                DescricaoCobertura = proposta.Cobertura.Descricao,
                FranquiaCobertura = proposta.Cobertura.Franquia,
                ValorFranquiaCobertura = proposta.Cobertura.ValorFranquia,
                LimiteIdenizacaoCobertura = proposta.Cobertura.LimiteIdenizacao,
                PremioCobertura = proposta.Cobertura.Premio,
                CategoriaBem = proposta.Bem.Categoria,
                MarcaBem = proposta.Bem.Marca,
                UtilizacaoBem = proposta.Bem.Utilizacao,
                PlacaBem = proposta.Bem.Placa,
                AnoFabricacaoBem = proposta.Bem.AnoFabricacao
            };

        }
    }
}
