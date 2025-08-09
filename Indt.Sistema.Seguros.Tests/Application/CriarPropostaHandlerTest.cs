using Indt.Sistema.Seguros.App.API.Propostas.CriarProposta;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks;
using Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;
using Moq;


namespace Indt.Sistema.Seguros.Tests.Application
{
    public class CriarPropostaHandlerTest
    {
        private readonly CriarPropostaHandler criarPropostaHandler;
        private readonly Mock<INotification> _notificacao;
        private readonly Mock<IPropostaRepository> _propostaRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CriarPropostaHandlerTest()
        {
            _notificacao = new Mock<INotification>();
            _propostaRepository = new Mock<IPropostaRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();

            criarPropostaHandler = new CriarPropostaHandler(_propostaRepository.Object,_notificacao.Object, _unitOfWork.Object);    
        }

        [Fact]
        public async Task CriarProposta_RequestValido_DeveRetornarSucesso()
        {
            //Arrange
            var idProposta = Guid.NewGuid();
            var proposta = PropostaFixture.ObterPropostaMock(idProposta);
            var request = new CriarPropostaRequest()
            {
                Numero = proposta.Numero,
                Valor = proposta.Valor,
                DataFim = proposta.DataFim,
                DataInicio = proposta.DataInicio,
                BemMovel = new BemMovelDto()
                {
                    AnoFabricacao = proposta.Bem.AnoFabricacao,
                    Categoria = proposta.Bem.Categoria,
                    Chassi = proposta.Bem.Chassi,
                    Cor = proposta.Bem.Cor,
                    Marca = proposta.Bem.Marca,
                    Placa = proposta.Bem.Placa,
                    Utilizacao = proposta.Bem.Utilizacao
                },
                Cliente = new ClienteDto()
                {
                    DataNescimento = proposta.Cliente.DataNescimento,
                    Documento = proposta.Cliente.Documento,
                    Nome = proposta.Cliente.Nome,
                    Contato = new ContatoClienteDto() 
                    {
                        Ddd = proposta.Cliente.Contato.Ddd,
                        Email = proposta.Cliente.Contato.Email,
                        Numero = proposta.Cliente.Contato.Numero
                    },
                    Endereco = new EnderecoClienteDto()
                    {
                        Bairro = proposta.Cliente.Endereco.Bairro,
                        Cep = proposta.Cliente.Endereco.Cep,
                        Cidade = proposta.Cliente.Endereco.Cidade,
                        Estado = proposta.Cliente.Endereco.Estado,
                        Logradouro = proposta.Cliente.Endereco.Logradouro,
                        Numero = proposta.Cliente.Endereco.Numero
                    }
                },
                Cobertura = new CoberturaDto()
                {
                    Descricao = proposta.Cobertura.Descricao,
                    Franquia = proposta.Cobertura.Franquia,
                    LimiteIdenizacao = proposta.Cobertura.LimiteIdenizacao,
                    Premio = proposta.Cobertura.Premio,
                    ValorFranquia = proposta.Cobertura.ValorFranquia
                }
            };

            _propostaRepository.Setup(c => c.CriarAsync
            (
                It.IsAny<Proposta>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(idProposta);        

            //Act
            var resultado = await criarPropostaHandler.Handle(request, CancellationToken.None);

            //Assert

            Assert.True(resultado.Sucesso);
            Assert.NotNull(resultado);
            Assert.Equal(idProposta, resultado.PropostaId);

            _propostaRepository.Verify(c => c.CriarAsync
            (
                It.IsAny<Proposta>(),
                It.IsAny<CancellationToken>()
            )
            , Times.Once());

        }

        [Fact]
        public async Task CriarProposta_RequestInvalido_DeveRetornarFalha()
        {
            //Arrange
            var idProposta = Guid.NewGuid();
            var proposta = PropostaFixture.ObterPropostaMock(idProposta);
            var request = new CriarPropostaRequest()
            {
                Numero = 0,
                Valor = proposta.Valor,
                DataFim = proposta.DataFim,
                DataInicio = proposta.DataInicio,
                BemMovel = new BemMovelDto()
                {
                    AnoFabricacao = string.Empty,
                    Categoria = proposta.Bem.Categoria,
                    Chassi = proposta.Bem.Chassi,
                    Cor = proposta.Bem.Cor,
                    Marca = proposta.Bem.Marca,
                    Placa = proposta.Bem.Placa,
                    Utilizacao = proposta.Bem.Utilizacao
                },
                Cliente = new ClienteDto()
                {
                    DataNescimento = proposta.Cliente.DataNescimento,
                    Documento = proposta.Cliente.Documento,
                    Nome = proposta.Cliente.Nome,
                    Contato = new ContatoClienteDto()
                    {
                        Ddd = proposta.Cliente.Contato.Ddd,
                        Email = proposta.Cliente.Contato.Email,
                        Numero = proposta.Cliente.Contato.Numero
                    },
                    Endereco = new EnderecoClienteDto()
                    {
                        Bairro = proposta.Cliente.Endereco.Bairro,
                        Cep = proposta.Cliente.Endereco.Cep,
                        Cidade = proposta.Cliente.Endereco.Cidade,
                        Estado = proposta.Cliente.Endereco.Estado,
                        Logradouro = proposta.Cliente.Endereco.Logradouro,
                        Numero = proposta.Cliente.Endereco.Numero
                    }
                },
                Cobertura = new CoberturaDto()
                {
                    Descricao = proposta.Cobertura.Descricao,
                    Franquia = proposta.Cobertura.Franquia,
                    LimiteIdenizacao = proposta.Cobertura.LimiteIdenizacao,
                    Premio = proposta.Cobertura.Premio,
                    ValorFranquia = proposta.Cobertura.ValorFranquia
                }
            };

            _propostaRepository.Setup(c => c.CriarAsync
            (
                It.IsAny<Proposta>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(idProposta);

            //Act
            var resultado = await criarPropostaHandler.Handle(request, CancellationToken.None);

            //Assert

            Assert.False(resultado.Sucesso);
            Assert.NotNull(resultado);
            

            _propostaRepository.Verify(c => c.CriarAsync
            (
                It.IsAny<Proposta>(),
                It.IsAny<CancellationToken>()
            )
            , Times.Never());

        }
    }
}
