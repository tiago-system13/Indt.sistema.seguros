using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Indt.Sistema.Seguros.Infra.DataBase.Models.PropostaAgreggate;

namespace Indt.Sistema.Seguros.Infra.DataBase.Models.ContratoAgreggate
{
    public class ContratoBuilder
    {
        public static void Build(EntityTypeBuilder<ContratoEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Prazo).IsRequired();
            builder.Property(x => x.DataInicial).HasColumnType("DateTimeOffset").IsRequired();
            builder.Property(x => x.DataFinal).HasColumnType("DateTimeOffset").IsRequired();
            builder.Property(x => x.DataDeCriacao).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.DataDeAlteracao).HasColumnType("DateTime");
            builder.Property(x => x.PropostaId).IsRequired();

            builder.HasOne(u => u.Proposta)
           .WithOne(up => up.Contrato)
           .HasForeignKey<ContratoEntity>(up => up.PropostaId);

            builder.ToTable("Tb_Contrato");
        }
    }
}
