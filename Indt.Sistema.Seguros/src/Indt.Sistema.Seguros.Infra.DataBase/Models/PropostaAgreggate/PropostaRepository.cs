using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate;
using Indt.Sistema.Seguros.Domain.ObjectValues;
using Indt.Sistema.Seguros.Domain.Shared.Enums;
using Indt.Sistema.Seguros.Domain.Shared.Notifications;
using Indt.Sistema.Seguros.Infra.DataBase.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Indt.Sistema.Seguros.Infra.DataBase.Models.PropostaAgreggate
{
    internal class PropostaRepository : IPropostaRepository
    {
        private readonly SegurosContext _context;
        private readonly INotification _notificacao;
        private readonly ILogger _logger;

        public PropostaRepository(SegurosContext context, INotification notificacao, ILogger logger)
        {
            _context = context;
            _notificacao = notificacao;
            _logger = logger;
        }

        public async ValueTask AtualizarAsync(Proposta proposta, CancellationToken cancellationToken = default)
        {
            var propostaEntity = await _context.Propostas.FirstOrDefaultAsync(x => x.Id == proposta.Id, cancellationToken);

            if (propostaEntity == null)
            {
                var mensagem = "Proposta não econtrada";
                var mensagemTemplate = $"PropostaRepository | Atualizar | Mensagem : {mensagem}";
                _logger.Warning(mensagemTemplate);
                _notificacao.AddNotificacao("PROPOSTA_NAOENCONTRADA", mensagem);
                return;
            }

            AtualizarProposta(proposta, propostaEntity);

            _context.Update(propostaEntity);
        }

        public async ValueTask AtualizarStatusProposta(StatusProposta statusProposta, Guid id, CancellationToken cancellationToken = default)
        {
            var propostaEntity = await _context.Propostas.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (propostaEntity == null)
            {
                var mensagem = "Proposta não econtrada";
                var mensagemTemplate = $"PropostaRepository | Atualizar | Mensagem : {mensagem}";
                _logger.Warning(mensagemTemplate);
                _notificacao.AddNotificacao("PROPOSTA_NAOENCONTRADA", mensagem);
                return;
            }

            propostaEntity.StatusProposta = (int)statusProposta;
            propostaEntity.DataDeAlteracao = DateTime.UtcNow;
            _context.Update(propostaEntity);
        }

        public async ValueTask<Guid?> CriarAsync(Proposta proposta, CancellationToken cancellationToken = default)
        {
            var propostaEntity = MapearPropostaEntity(proposta);
            await _context.Propostas.AddAsync(propostaEntity, cancellationToken);
            return propostaEntity.Id;
        }

        public async ValueTask<Proposta?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var propostaEntity = await _context.Propostas.FirstOrDefaultAsync(x=> x.Id == id, cancellationToken);

            if(propostaEntity == null)
            {
                var mensagem = "Proposta não econtrada";
                var mensagemTemplate = $"PropostaRepository | Atualizar | Mensagem : {mensagem}";
                _logger.Warning(mensagemTemplate);
                _notificacao.AddNotificacao("PROPOSTA_NAOENCONTRADA", mensagem);
                return default;
            }

            return MapearProposta(propostaEntity);
        }

        public async ValueTask<Proposta?> ObterPorNumeroAsync(int numero, CancellationToken cancellationToken = default)
        {
            var propostaEntity = await _context.Propostas.FirstOrDefaultAsync(x => x.Numero == numero, cancellationToken);

            if (propostaEntity == null) return default;

            return MapearProposta(propostaEntity);
        }

        private PropostaEntity MapearPropostaEntity(Proposta proposta)
        {
            return new PropostaEntity
            (
                proposta.Id,
                proposta.DataDeCriacao,
                proposta.DataDeAlteracao,
                proposta.Numero,
                (int)proposta.TipoSeguro,
                proposta.DataInicio,
                proposta.DataFim,
                (int)proposta.StatusProposta,
                proposta.Valor,
                proposta.Prazo,
                proposta.Cliente.Documento,
                proposta.Cliente.Nome,
                proposta.Cliente.DataNescimento,
                proposta.Cliente.Endereco.Numero,
                proposta.Cliente.Endereco.Logradouro,
                proposta.Cliente.Endereco.Cep,
                proposta.Cliente.Endereco.Bairro,
                proposta.Cliente.Endereco.Cidade,
                proposta.Cliente.Endereco.Estado,
                proposta.Cliente.Contato.Numero,
                proposta.Cliente.Contato.Ddd,
                proposta.Cliente.Contato.Email,
                proposta.Bem.Marca,
                proposta.Bem.AnoFabricacao,
                proposta.Bem.Placa,
                (int)proposta.Bem.Categoria,
                proposta.Bem.Utilizacao,
                proposta.Bem.Cor,
                proposta.Bem.Chassi,
                proposta.Cobertura.Descricao,
                proposta.Cobertura.LimiteIdenizacao,
                proposta.Cobertura.Premio,
                proposta.Cobertura.Franquia,
                proposta.Cobertura.ValorFranquia);
        }

        private Proposta MapearProposta(PropostaEntity propostaEntity)
        {
            return new Proposta
            (
                propostaEntity.Numero,
                propostaEntity.DataInicio,
                propostaEntity.DataFim,
                (StatusProposta)propostaEntity.StatusProposta,
                (TipoSeguro)propostaEntity.TipoSeguro,
                propostaEntity.Valor,
                propostaEntity.Prazo,
                new Cliente
                (
                    propostaEntity.DocumentoCliente,
                    propostaEntity.NomeCliente,
                    propostaEntity.DataNascimentoCliente,
                    new Endereco
                    (
                        propostaEntity.NumeroEnderecoCliente,
                        propostaEntity.LogradouroEnderecoCliente,
                        propostaEntity.CepEnderecoCliente,
                        propostaEntity.BairroEnderecoCliente,
                        propostaEntity.CidadeEnderecoCliente,
                        propostaEntity.EstadoEnderecoCliente),
                    new Contato
                    (
                        propostaEntity.NumeroContatoCliente,
                        propostaEntity.DddContatoCliente,
                        propostaEntity.EmailContatoCliente
                    )
                ), 
                new Bem
                (
                    propostaEntity.MarcaBem,
                    propostaEntity.AnoFabricacaoBem,
                    propostaEntity.PlacaBem,
                    (Categoria)propostaEntity.CategoriaBem,
                    propostaEntity.UtilizacaoBem,
                    propostaEntity.CorBem,
                    propostaEntity.ChassiBem
                ),
                new Cobertura
                (
                    propostaEntity.DescricaoCobertura,
                    propostaEntity.LimiteIdenizacaoCobertura,
                    propostaEntity.PremioCobertura,
                    propostaEntity.FranquiaCobertura,
                    propostaEntity.ValorFranquiaCobertura
                 ),
                propostaEntity.Id
            );
        }

        private void AtualizarProposta(Proposta proposta, PropostaEntity propostaEntity)
        {
            if ( proposta != null )
            {
                propostaEntity.Numero = proposta.Numero;
                propostaEntity.Prazo = proposta.Prazo;
                propostaEntity.DataInicio = proposta.DataInicio;
                propostaEntity.DataFim = proposta.DataFim;
                propostaEntity.DocumentoCliente = proposta.Cliente.Documento;
                propostaEntity.NomeCliente = proposta.Cliente.Nome;
                propostaEntity.DataNascimentoCliente = proposta.Cliente.DataNescimento;
                propostaEntity.NumeroEnderecoCliente = proposta.Cliente.Endereco.Numero;
                propostaEntity.LogradouroEnderecoCliente = proposta.Cliente.Endereco.Logradouro;
                propostaEntity.CepEnderecoCliente = proposta.Cliente.Endereco.Cep;
                propostaEntity.BairroEnderecoCliente = proposta.Cliente.Endereco.Bairro;
                propostaEntity.CidadeEnderecoCliente = proposta.Cliente.Endereco.Cidade;
                propostaEntity.EstadoEnderecoCliente = proposta.Cliente.Endereco.Estado;
                propostaEntity.AnoFabricacaoBem = proposta.Bem.AnoFabricacao;
                propostaEntity.MarcaBem = proposta.Bem.Marca;
                propostaEntity.ChassiBem = proposta.Bem.Chassi;
                propostaEntity.CorBem = proposta.Bem.Cor;
                propostaEntity.CategoriaBem = (int)proposta.Bem.Categoria;
                propostaEntity.PlacaBem = proposta.Bem.Placa;
                propostaEntity.UtilizacaoBem = proposta.Bem.Utilizacao;
                propostaEntity.DescricaoCobertura = proposta.Cobertura.Descricao;
                propostaEntity.FranquiaCobertura = proposta.Cobertura.Franquia;
                propostaEntity.ValorFranquiaCobertura = proposta.Cobertura.ValorFranquia;
                propostaEntity.PremioCobertura = proposta.Cobertura.Premio;
                propostaEntity.LimiteIdenizacaoCobertura = proposta.Cobertura.LimiteIdenizacao;


            }
        }
    }
}
