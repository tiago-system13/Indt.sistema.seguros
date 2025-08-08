namespace Indt.Sistema.Seguros.Domain.ObjectValues
{
    public class Endereco
    {
        public int Numero { get; init; }

        public string Logradouro { get; init; }

        public string Cep { get; init; }

        public string Bairro { get; init; }

        public string Cidade { get; init; }

        public string Estado { get; init; }

        public Endereco(int numero, string logradouro, string cep, string bairro, string cidade, string estado)
        {
            Numero = numero;
            Logradouro = logradouro;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
