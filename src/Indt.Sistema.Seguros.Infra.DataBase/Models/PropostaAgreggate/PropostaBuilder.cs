using Indt.Sistema.Seguros.Infra.DataBase.Models.ContratoAgreggate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indt.Sistema.Seguros.Infra.DataBase.Models.PropostaAgreggate
{
    public class PropostaBuilder
    {
        public static void Build(EntityTypeBuilder<PropostaEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Prazo).IsRequired();
            builder.Property(x => x.DataInicio).HasColumnType("DateTimeOffset").IsRequired();
            builder.Property(x => x.DataFim).HasColumnType("DateTimeOffset").IsRequired();
            builder.Property(x => x.DataDeCriacao).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.DataDeAlteracao).HasColumnType("DateTime");
            builder.Property(x => x.StatusProposta).IsRequired();
            builder.Property(x => x.DocumentoCliente).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.NomeCliente).HasColumnType("varchar(80)").IsRequired();
            builder.Property(x => x.DataNascimentoCliente).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.NumeroEnderecoCliente).IsRequired();
            builder.Property(x => x.LogradouroEnderecoCliente).HasColumnType("varchar(80)").IsRequired();
            builder.Property(x => x.CepEnderecoCliente).HasColumnType("varchar(9)").IsRequired();
            builder.Property(x => x.BairroEnderecoCliente).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.CidadeEnderecoCliente).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.EstadoEnderecoCliente).HasColumnType("varchar(2)").IsRequired();
            builder.Property(x => x.DddContatoCliente).HasColumnType("varchar(3)").IsRequired();
            builder.Property(x => x.NumeroContatoCliente).HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.EmailContatoCliente).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.AnoFabricacaoBem).HasColumnType("varchar(4)").IsRequired();
            builder.Property(x => x.MarcaBem).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.CategoriaBem).IsRequired();
            builder.Property(x => x.ChassiBem).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.CorBem).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.PlacaBem).HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.UtilizacaoBem).HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.FranquiaCobertura).IsRequired();
            builder.Property(x => x.DescricaoCobertura).HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.LimiteIdenizacaoCobertura).HasColumnType("varchar(80)").IsRequired();
            builder.Property(x => x.PremioCobertura).IsRequired();
            builder.Property(x => x.ValorFranquiaCobertura).IsRequired();

            builder.ToTable("Tb_Proposta");
        }
    }
}
