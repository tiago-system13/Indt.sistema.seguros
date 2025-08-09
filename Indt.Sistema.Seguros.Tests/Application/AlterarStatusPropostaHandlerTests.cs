using Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta;
using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using Indt.Sistema.Seguros.Domain.Adapters.Producers;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks;
using Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;
using Moq;

namespace Indt.Sistema.Seguros.Tests.Application
{
    public class AlterarStatusPropostaHandlerTests
    {
        private readonly Mock<IPropostaRepository> _propostaRepository;
        private readonly Mock<IContratoCriadoProducer> _contratoCriadoProducer;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<INotification> _notificacao;
        private readonly AlterarStatusPropostaHandler _alterarStatusPropostaHandler;

        public AlterarStatusPropostaHandlerTests()
        {
            _notificacao = new Mock<INotification>();
            _propostaRepository = new Mock<IPropostaRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _contratoCriadoProducer = new Mock<IContratoCriadoProducer>();
            _alterarStatusPropostaHandler = new AlterarStatusPropostaHandler(_propostaRepository.Object,_contratoCriadoProducer.Object,_unitOfWork.Object,_notificacao.Object);
        }

        [Fact]
        public async Task AlterarStatusProposta_RequestValido_DeveRetornarSucesso()
        {
            //Arrange
            var alterarStatusProposta = new AlterarStatusPropostaRequest()
            {
                PropostaId = Guid.NewGuid(),
                StatusProposta = Seguros.Domain.Shared.Enums.StatusProposta.Aprovada
            };

            var proposta = PropostaFixture.ObterPropostaMock(alterarStatusProposta.PropostaId);


            _propostaRepository.Setup(p => p.ObterPorIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(proposta);

            _propostaRepository.Setup(c => c.AtualizarStatusProposta
           (
               It.IsAny<StatusProposta>(),
               It.IsAny<Guid>(),
               It.IsAny<CancellationToken>()
           ));

            //Act
            var resultado = await _alterarStatusPropostaHandler.Handle(alterarStatusProposta, CancellationToken.None);


            //Assert

            Assert.True(resultado.Sucesso);
            Assert.Equal(alterarStatusProposta.PropostaId, resultado.PropostaId);


            _propostaRepository.Verify(c => c.AtualizarStatusProposta
           (
               It.IsAny<StatusProposta>(),
               It.IsAny<Guid>(),
               It.IsAny<CancellationToken>()
           ), Times.Once());

            _contratoCriadoProducer.Verify(x=> x.CriarContrato(It.IsAny<ContratoCriadoCommand>()), Times.Once());
        }

        [Fact]
        public async Task AlterarStatusProposta_RequestInvalidoValido_DeveRetornarFalha()
        {
            //Arrange
            var alterarStatusProposta = new AlterarStatusPropostaRequest()
            {
                PropostaId = Guid.NewGuid(),
                StatusProposta = Seguros.Domain.Shared.Enums.StatusProposta.Aprovada
            };

            var proposta = PropostaFixture.ObterPropostaMock(alterarStatusProposta.PropostaId);


            _propostaRepository.Setup(p => p.ObterPorIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Proposta)null);

            _propostaRepository.Setup(c => c.AtualizarStatusProposta
           (
               It.IsAny<StatusProposta>(),
               It.IsAny<Guid>(),
               It.IsAny<CancellationToken>()
           ));

            //Act
            var resultado = await _alterarStatusPropostaHandler.Handle(alterarStatusProposta, CancellationToken.None);


            //Assert

            Assert.False(resultado.Sucesso);
            Assert.Equal(alterarStatusProposta.PropostaId, resultado.PropostaId);


            _propostaRepository.Verify(c => c.AtualizarStatusProposta
           (
               It.IsAny<StatusProposta>(),
               It.IsAny<Guid>(),
               It.IsAny<CancellationToken>()
           ), Times.Never());

            _contratoCriadoProducer.Verify(x => x.CriarContrato(It.IsAny<ContratoCriadoCommand>()), Times.Never());
        }
    }
}
