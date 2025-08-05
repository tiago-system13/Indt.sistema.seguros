using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Indt.Sistema.Seguros.Infra.DataBase.Models.ContratoAgreggate
{
    public class ParcelaBuilder
    {
        public static void Build(EntityTypeBuilder<ParcelaEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Data).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.DataDeCriacao).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.DataDeAlteracao).HasColumnType("DateTime");
            builder.Property(x => x.ContratoId).IsRequired();
            builder.HasOne(x => x.ContratoEntity)
                   .WithMany(x => x.Parcelas)
                   .HasForeignKey(x=> x.ContratoId);

            builder.ToTable("Tb_Parcela");
        }
    }
}
