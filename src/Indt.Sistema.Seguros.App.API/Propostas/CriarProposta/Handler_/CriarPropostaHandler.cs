using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks;
using Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate;
using Indt.Sistema.Seguros.Domain.ObjectValues;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;

namespace Indt.Sistema.Seguros.App.API.Propostas.CriarProposta
{
    public class CriarPropostaHandler : IHandler<CriarPropostaRequest, CriarPropostaResponse>
    {
        private readonly INotification _notificacao;
        private readonly IPropostaRepository _propostaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CriarPropostaHandler
        (
            IPropostaRepository propostaRepository,
            INotification notificacao,
            IUnitOfWork unitOfWork)
        {
            _propostaRepository = propostaRepository;
            _notificacao = notificacao;
            _unitOfWork = unitOfWork;
        }
        public async Task<CriarPropostaResponse> Handle(CriarPropostaRequest request, CancellationToken cancellationToken)
        {
            Proposta proposta = PropostaMapper(request);

            if (proposta.Invalid)
            {
                _notificacao.AddNotificacoes(proposta.ValidationResult!);
                return new CriarPropostaResponse(Guid.Empty) { Sucesso = false };
            }

            await _unitOfWork.BeginTransaction();

            var propostaId = await _propostaRepository.CriarAsync(proposta, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransaction();

            return new CriarPropostaResponse(propostaId) { Sucesso = true , Mensagem = "Propsota cadastrada com sucesso!"};
        }

        private static Proposta PropostaMapper(CriarPropostaRequest request)
        {
             
            var proposta = new Proposta
            (
                request.Numero,
                request.DataInicio,
                request.DataFim,
                StatusProposta.Cadastrada,
                request.TipoSeguro,
                request.Valor,
                0,
                new Cliente
                (
                    request.Cliente.Documento,
                    request.Cliente.Nome,
                    request.Cliente.DataNescimento,
                    new Endereco
                    (
                        request.Cliente.Endereco.Numero,
                        request.Cliente.Endereco.Logradouro,
                        request.Cliente.Endereco.Cep,
                        request.Cliente.Endereco.Bairro,
                        request.Cliente.Endereco.Cidade,
                        request.Cliente.Endereco.Estado
                    ),
                    new Contato(request.Cliente.Contato.Numero, request.Cliente.Contato.Ddd, request.Cliente.Contato.Email)
                ),
                new Bem
                (
                    request.BemMovel.Marca,
                    request.BemMovel.AnoFabricacao,
                    request.BemMovel.Placa,
                    request.BemMovel.Categoria,
                    request.BemMovel.Utilizacao,
                    request.BemMovel.Cor,
                    request.BemMovel.Chassi
                ),
                new Cobertura
                (
                    request.Cobertura.Descricao,
                    request.Cobertura.LimiteIdenizacao,
                    request.Cobertura.Premio,
                    request.Cobertura.Franquia,
                    request.Cobertura.ValorFranquia
                 )
            );

            proposta.SetarPrazoProposta(request.DataInicio, request.DataFim);

            return proposta;
        }

    }
}
