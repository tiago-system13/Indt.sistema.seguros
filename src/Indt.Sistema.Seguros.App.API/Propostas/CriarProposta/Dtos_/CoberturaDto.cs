namespace Indt.Sistema.Seguros.App.API.Propostas.CriarProposta
{
    public class CoberturaDto
    {
        public string Descricao { get;  set; }

        public string LimiteIdenizacao { get;  set; }

        public decimal Premio { get;  set; }

        public bool Franquia { get;  set; }
        public decimal ValorFranquia { get;  set; }
    }
}
