namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class Cobertura
    {
        public string Descricao { get; init; }

        public string LimiteIdenizacao{ get; init; }

        public decimal Premio { get; init; }

        public bool Franquia { get; init; }
        public decimal ValorFranquia { get; init; }

        public Cobertura(string descricao, string limiteIdenizacao, decimal premio, bool franquia, decimal valorFranquia)
        {
            Descricao = descricao;
            LimiteIdenizacao = limiteIdenizacao;
            Premio = premio;
            Franquia = franquia;
            ValorFranquia = valorFranquia;
        }
    }
}
