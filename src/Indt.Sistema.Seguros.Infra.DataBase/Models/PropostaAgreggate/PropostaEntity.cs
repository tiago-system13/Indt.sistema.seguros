using Indt.Sistema.Seguros.Infra.DataBase.Models.ContratoAgreggate;

namespace Indt.Sistema.Seguros.Infra.DataBase.Models.PropostaAgreggate
{
    public class PropostaEntity
    {
        public Guid? Id { get; private set; } 
        public DateTime DataDeCriacao { get; private set; } 
        public DateTime? DataDeAlteracao { get; set; } 
        public int Numero { get;  set; } 
        public int TipoSeguro { get;  set; } 
        public DateTimeOffset DataInicio { get;  set; } 
        public DateTimeOffset DataFim { get;  set; } 
        public int StatusProposta { get; set; } 
        public decimal Valor { get;  set; } 
        public int Prazo { get;  set; } 
        public string DocumentoCliente { get;  set; } 
        public string NomeCliente { get;  set; } 
        public DateTime DataNascimentoCliente { get;  set; } 
        public int NumeroEnderecoCliente { get;  set; } 
        public string LogradouroEnderecoCliente { get;  set; } 
        public string CepEnderecoCliente { get;  set; } 
        public string BairroEnderecoCliente { get;  set; } 
        public string CidadeEnderecoCliente { get;  set; } 
        public string EstadoEnderecoCliente { get;  set; } 
        public string NumeroContatoCliente { get;  set; } 
        public string DddContatoCliente { get;  set; } 
        public string EmailContatoCliente { get;  set; } 
        public string MarcaBem { get;  set; } 
        public string AnoFabricacaoBem { get;  set; } 
        public string PlacaBem { get;  set; } 
        public int CategoriaBem { get;  set; } 
        public string UtilizacaoBem { get;  set; } 
        public string CorBem { get;  set; } 
        public string ChassiBem { get;  set; } 
        public string DescricaoCobertura { get;  set; } 
        public string LimiteIdenizacaoCobertura { get;  set; }
        public decimal PremioCobertura { get;  set; } 
        public bool FranquiaCobertura { get;  set; } 
        public decimal ValorFranquiaCobertura { get;  set; }
        public ContratoEntity Contrato { get;  set; }

        public PropostaEntity(Guid? id, DateTime dataDeCriacao, DateTime? dataDeAlteracao, int numero, int tipoSeguro, DateTimeOffset dataInicio, DateTimeOffset dataFim, int statusProposta, decimal valor, int prazo, string documentoCliente, string nomeCliente, DateTime dataNascimentoCliente, int numeroEnderecoCliente, string logradouroEnderecoCliente, string cepEnderecoCliente, string bairroEnderecoCliente, string cidadeEnderecoCliente, string estadoEnderecoCliente, string numeroContatoCliente, string dddContatoCliente, string emailContatoCliente, string marcaBem, string anoFabricacaoBem, string placaBem, int categoriaBem, string utilizacaoBem, string corBem, string chassiBem, string descricaoCobertura, string limiteIdenizacaoCobertura, decimal premioCobertura, bool franquiaCobertura, decimal valorFranquiaCobertura)
        {
            Id = id;
            DataDeCriacao = dataDeCriacao;
            DataDeAlteracao = dataDeAlteracao;
            Numero = numero;
            TipoSeguro = tipoSeguro;
            DataInicio = dataInicio;
            DataFim = dataFim;
            StatusProposta = statusProposta;
            Valor = valor;
            Prazo = prazo;
            DocumentoCliente = documentoCliente;
            NomeCliente = nomeCliente;
            DataNascimentoCliente = dataNascimentoCliente;
            NumeroEnderecoCliente = numeroEnderecoCliente;
            LogradouroEnderecoCliente = logradouroEnderecoCliente;
            CepEnderecoCliente = cepEnderecoCliente;
            BairroEnderecoCliente = bairroEnderecoCliente;
            CidadeEnderecoCliente = cidadeEnderecoCliente;
            EstadoEnderecoCliente = estadoEnderecoCliente;
            NumeroContatoCliente = numeroContatoCliente;
            DddContatoCliente = dddContatoCliente;
            EmailContatoCliente = emailContatoCliente;
            MarcaBem = marcaBem;
            AnoFabricacaoBem = anoFabricacaoBem;
            PlacaBem = placaBem;
            CategoriaBem = categoriaBem;
            UtilizacaoBem = utilizacaoBem;
            CorBem = corBem;
            ChassiBem = chassiBem;
            DescricaoCobertura = descricaoCobertura;
            LimiteIdenizacaoCobertura = limiteIdenizacaoCobertura;
            PremioCobertura = premioCobertura;
            FranquiaCobertura = franquiaCobertura;
            ValorFranquiaCobertura = valorFranquiaCobertura;
        }
    }
}
