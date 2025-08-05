using Indt.Sistema.Seguros.App.API.Shared;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate;
using Indt.Sistema.Seguros.Domain.ObjectValues;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;

namespace Indt.Sistema.Seguros.App.API.Propostas.CriarProposta
{
    internal class CriarPropostaHandler : IHandler<CriarPropostaRequest, CriarPropostaResponse>
    {
        private readonly INotification _notificacao;
        private readonly IPropostaRepository _propostaRepository;

        public CriarPropostaHandler(IPropostaRepository propostaRepository, INotification notificacao)
        {
            _propostaRepository = propostaRepository;
            _notificacao = notificacao;
        }
        public async Task<CriarPropostaResponse> Handle(CriarPropostaRequest request, CancellationToken cancellationToken)
        {
            Proposta proposta = PropostaMapper(request);

            if (proposta.Invalid)
            {
                _notificacao.AddNotificacoes(proposta.ValidationResult!);
                return new CriarPropostaResponse(Guid.Empty);
            }

            return new CriarPropostaResponse((await _propostaRepository.CriarAsync(proposta, cancellationToken)).Value);
        }

        private static Proposta PropostaMapper(CriarPropostaRequest request)
        {
            return new Proposta
            (
                request.Numero,
                request.DataInicio,
                request.DataFim,
                request.StatusProposta,
                request.TipoSeguro,
                request.Valor,
                request.Prazo,
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
        }
    }
}
