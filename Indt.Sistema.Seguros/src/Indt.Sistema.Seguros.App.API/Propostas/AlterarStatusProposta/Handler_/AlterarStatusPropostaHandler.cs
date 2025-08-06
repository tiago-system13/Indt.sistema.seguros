using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Adapters.Producers;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Shared.Enums;

namespace Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta
{
    internal class AlterarStatusPropostaHandler : IHandler<AlterarStatusPropostaRequest, AlterarStatusPropostaResponse>
    {        
        private readonly IPropostaRepository _propostaRepository;
        private readonly IContratoCriadoProducer  _contratoCriadoProducer;

        public AlterarStatusPropostaHandler(IPropostaRepository propostaRepository, IContratoCriadoProducer contratoCriadoProducer)
        {            
            _propostaRepository = propostaRepository;
            _contratoCriadoProducer = contratoCriadoProducer;
        }

        public async Task<AlterarStatusPropostaResponse> Handle(AlterarStatusPropostaRequest request, CancellationToken cancellationToken)
        {

            await _propostaRepository.AtualizarStatusProposta(request.StatusProposta, request.PropostaId, cancellationToken);

            if (request.StatusProposta.Equals(StatusProposta.Aprovada))
            {

                var proposta = await _propostaRepository.ObterPorIdAsync(request.PropostaId, cancellationToken);

                if(proposta != null)
                {

                    await _contratoCriadoProducer.CriarContrato(new Domain.Adapters.Commands.ContratoCriadoCommand()
                    {
                        DataInicial = proposta.DataInicio,
                        DataFinal = proposta.DataFim,
                        Numero = proposta.Numero + 1,                        
                        Prazo = proposta.Prazo,
                        Valor = proposta.Valor,
                    });
                }

                return new AlterarStatusPropostaResponse(proposta.Id.Value);             
            }


            return new AlterarStatusPropostaResponse(request.PropostaId);
                
        }
    }
}
