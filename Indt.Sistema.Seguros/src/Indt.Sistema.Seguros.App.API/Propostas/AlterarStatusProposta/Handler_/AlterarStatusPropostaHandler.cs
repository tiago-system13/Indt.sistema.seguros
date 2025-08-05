using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;

namespace Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta
{
    internal class AlterarStatusPropostaHandler : IHandler<AlterarStatusPropostaRequest, AlterarStatusPropostaResponse>
    {
        private readonly INotification _notificacao;
        private readonly IPropostaRepository _propostaRepository;


        public Task<AlterarStatusPropostaResponse> Handle(AlterarStatusPropostaRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
