namespace Indt.Sistema.Seguros.Domain.Shared
{
    public class Notificacao
    {
        public string? Mensagem { get; set; }

        public string? Codigo { get; set; }

        public Notificacao(string? mensagem, string? codigo)
        {
            Mensagem = mensagem;
            Codigo = codigo;
        }
    }
}
