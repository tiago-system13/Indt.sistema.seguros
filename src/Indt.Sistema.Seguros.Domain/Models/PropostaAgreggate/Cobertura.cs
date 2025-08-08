namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class Cobertura
    {
        public string Descricao { get; private set; }

        public string LimiteIdenizacao { get; private set; }

        public decimal Premio { get; private set; }

        public bool Franquia { get; private set; }
        public decimal ValorFranquia { get; private set; }

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
