using Indt.Sistema.Seguros.Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indt.Sistema.Seguros.App.API.Propostas.CriarProposta
{
    public class ClienteDto
    {
        public string Documento { get; set; }

        public string Nome { get; set; }

        public DateTime DataNescimento { get; set; }

        public EnderecoClienteDto Endereco { get; set; }

        public ContatoClienteDto Contato { get; set; }
    }
}
