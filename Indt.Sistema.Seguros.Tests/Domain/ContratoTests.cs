using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;

namespace Indt.Sistema.Seguros.Tests.Domain
{
    public class ContratoTests
    {
        [Fact]
        public void CriarContratoComparcela_Ok()
        {
            //Arrange
            var contrato = new Contrato(123, DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1), Guid.NewGuid(), 3000,12);

            var valorParcela = 250M;

            //Act
           var resultado =  contrato.CalcularValorParcela(contrato.Valor, contrato.Prazo);

            //Assert
            Assert.Equal(valorParcela, resultado);
        }

        [Fact]
        public void GerarParcelas_Ok()
        {
            //Arrange
            var contrato = new Contrato(123, DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1), Guid.NewGuid(), 3000, 12);

            var quantidadeParcels = 12;

            //Act
            contrato.GerarParcelas(contrato.Valor, contrato.Prazo);

            //Assert
            Assert.Equal(quantidadeParcels, contrato.Parcelas.Count);
        }
    }
}
