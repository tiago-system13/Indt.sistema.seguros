namespace Indt.Sistema.Seguros.Domain.ObjectValues
{
    public record Contato(string Numero, string Ddd, string Email)
    {
        public string Numero { get; private set; } = Numero;
        public string Ddd { get; private set; } = Ddd;
        public string Email { get; private set; } = Email;
    }
}
