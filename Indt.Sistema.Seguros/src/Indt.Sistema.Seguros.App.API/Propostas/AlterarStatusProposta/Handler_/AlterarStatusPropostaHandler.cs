using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Adapters.Producers;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;

namespace Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta
{
    internal class AlterarStatusPropostaHandler : IHandler<AlterarStatusPropostaRequest, AlterarStatusPropostaResponse>
    {
        private readonly INotification _notificacao;
        private readonly IPropostaRepository _propostaRepository;
        private readonly IContratoCriadoProducer  _contratoCriadoProducer;

        public AlterarStatusPropostaHandler(INotification notificacao, IPropostaRepository propostaRepository, IContratoCriadoProducer contratoCriadoProducer)
        {
            _notificacao = notificacao;
            _propostaRepository = propostaRepository;
            _contratoCriadoProducer = contratoCriadoProducer;
        }

        public Task<AlterarStatusPropostaResponse> Handle(AlterarStatusPropostaRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
