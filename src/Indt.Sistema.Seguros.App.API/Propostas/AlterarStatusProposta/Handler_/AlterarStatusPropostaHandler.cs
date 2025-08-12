using Indt.Sistema.Seguros.App.API.Propostas.CriarProposta;
using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Adapters.Producers;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks;
using Indt.Sistema.Seguros.Domain.Shared;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;
using MassTransit;

namespace Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta
{
    public class AlterarStatusPropostaHandler : IHandler<AlterarStatusPropostaRequest, AlterarStatusPropostaResponse>
    {        
        private readonly IPropostaRepository _propostaRepository;
        private readonly IContratoCriadoProducer  _contratoCriadoProducer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotification _notificacao;

        public AlterarStatusPropostaHandler
        (
            IPropostaRepository propostaRepository,
            IContratoCriadoProducer contratoCriadoProducer,
            IUnitOfWork unitOfWork,
            INotification notificacao
        )
        {            
            _propostaRepository = propostaRepository;
            _contratoCriadoProducer = contratoCriadoProducer;
            _unitOfWork = unitOfWork;
            _notificacao = notificacao;
        }

        public async Task<AlterarStatusPropostaResponse> Handle(AlterarStatusPropostaRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransaction();

            var proposta = await _propostaRepository.ObterPorIdAsync(request.PropostaId, cancellationToken);

            if(proposta == null)
            {
                _notificacao.AddNotificacoes(proposta?.ValidationResult!);
                return new AlterarStatusPropostaResponse(request.PropostaId) { Sucesso = false};
            }

            await _propostaRepository.AtualizarStatusProposta(request.StatusProposta, request.PropostaId, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransaction();

            if ((proposta.StatusProposta.Equals(StatusProposta.Cadastrada) || proposta.StatusProposta.Equals(StatusProposta.Analise)) && request.StatusProposta.Equals(StatusProposta.Aprovada))
            {
                    await _contratoCriadoProducer.CriarContrato(new Domain.Adapters.Commands.ContratoCriadoCommand()
                    {
                        DataInicial = proposta.DataInicio,
                        DataFinal = proposta.DataFim,
                        Numero = proposta.Numero,                        
                        Prazo = proposta.Prazo,
                        Valor = proposta.Valor,
                        PropostaId = request.PropostaId
                    });

                return new AlterarStatusPropostaResponse(request.PropostaId) { Mensagem = "Atualizada com sucesso  e solicitação de criação de contrato realizado", Sucesso = true };
            }

            return new AlterarStatusPropostaResponse(request.PropostaId) { Mensagem = "Atualizada com sucesso", Sucesso = true };

        }
    }
}
