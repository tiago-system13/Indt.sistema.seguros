using Indt.Sistema.Seguros.App.Workers.CriarContrato;
using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks;
using Indt.Sistema.Seguros.Domain.Models.ContratoAgreggate;
using Moq;
using Serilog;

namespace Indt.Sistema.Seguros.Tests.Workers
{
    public class CriarContratoDispatcherTests
    {
        private readonly Mock<IContratoRepository> _contratoRepository;
        private readonly Mock<ILogger> _logger;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly CriarContratoDispatcher _criarContratoDispatcher;


        public CriarContratoDispatcherTests()
        {
            _logger = new Mock<ILogger>();
            _contratoRepository = new Mock<IContratoRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _criarContratoDispatcher = new CriarContratoDispatcher(_contratoRepository.Object, _unitOfWork.Object);
        }

        [Fact]
        public async Task CriarContrato_RequestValido_DeveRetornarSucesso()
        {
            var propostaId = Guid.NewGuid();
            var contratoCriadoCommand = new ContratoCriadoCommand()
            {
                Valor = 1500,
                PropostaId = propostaId,
                DataFinal = DateTimeOffset.Now.AddYears(5),
                DataInicial = DateTimeOffset.Now,
                Numero = 1,
                Prazo = 60
            };

            var contartoId = Guid.NewGuid();

            _contratoRepository.Setup(x => x.CriarAsync(It.IsAny<Contrato>(), It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(contartoId);

            await _criarContratoDispatcher.CriarContratoAsync(contratoCriadoCommand);

            //Assert

            _contratoRepository.Verify(x=> x.CriarAsync(It.IsAny<Contrato>(), It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
