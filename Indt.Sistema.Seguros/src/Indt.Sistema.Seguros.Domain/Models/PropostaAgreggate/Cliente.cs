using Indt.Sistema.Seguros.Domain.ObjectValues;

namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class Cliente
    {
        public string Documento { get; init; }

        public string Nome { get; init; }

        public DateTime DataNescimento { get; init; }

        public Endereco Endereco { get; init; }

        public Contato Contato { get; init; }

        public Cliente(string documento, string nome, DateTime dataNescimento, Endereco endereco, Contato contato)
        {
            Documento = documento;
            Nome = nome;
            DataNescimento = dataNescimento;
            Endereco = endereco;
            Contato = contato;
        }
    }
}
