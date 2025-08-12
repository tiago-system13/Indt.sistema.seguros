using Indt.Sistema.Seguros.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indt.Sistema.Seguros.App.API.Propostas.ListarPropostas
{
    public class PropostasDto
    {
        public Guid PropostaId { get; set; }
        public int Numero { get; set; }

        public TipoSeguro TipoSeguro { get; set; }

        public DateTimeOffset DataInicio { get; set; }

        public DateTimeOffset DataFim { get; set; }

        public StatusProposta StatusProposta { get; set; }

        public decimal Valor { get; set; }

        public int Prazo { get; set; }

        public string DocumentoCliente { get; set; }

        public string NomeCliente { get; set; }

        public string ContatoClinete { get; set; }

        public string MarcaBem { get; set; }

        public string AnoFabricacaoBem { get; set; }

        public string PlacaBem { get; set; }

        public Categoria CategoriaBem { get; set; }

        public string UtilizacaoBem { get; set; }

        public string DescricaoCobertura { get; set; }

        public string LimiteIdenizacaoCobertura { get; set; }

        public decimal PremioCobertura { get; set; }

        public bool FranquiaCobertura { get; set; }
        public decimal ValorFranquiaCobertura { get; set; }
    }
}
