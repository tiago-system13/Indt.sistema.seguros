using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
using Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indt.Sistema.Seguros.Tests.Domain
{
    public class PropostaTests
    {

        [Fact]
        public void CriarContratoComparcela_Ok()
        {
            //Arrange
            var proposta = new Proposta
            (
                123,
                DateTimeOffset.Now, 
                DateTimeOffset.Now.AddYears(1),
                Seguros.Domain.Shared.Enums.StatusProposta.Cadastrada,
                Seguros.Domain.Shared.Enums.TipoSeguro.Novo,
                5000,
                0,
                new Cliente
                (
                    "12323",
                    "Joao",
                    DateTime.UtcNow.AddYears(-25),
                    new Seguros.Domain.ObjectValues.Endereco(22,
                    "Rua B",
                    "22335663",
                    "Jabotiana",
                    "Aracaju",
                    "SE"),
                    new Seguros.Domain.ObjectValues.Contato("2356","79","joao.bomfim@gmail.com")
                ),
                new Bem("Yamaha","2025","EOK0987",Seguros.Domain.Shared.Enums.Categoria.Motocicleta,"Lazer","Preto","FKGLHKH67776"),
                new Cobertura("Seguro","Fipe",36000,true,3652)
             );

            var prazoEsperado = 12;

            //Act
            proposta.SetarPrazoProposta(proposta.DataInicio, proposta.DataFim);

            //Assert
            Assert.Equal(prazoEsperado, proposta.Prazo);
        }
    }
}
