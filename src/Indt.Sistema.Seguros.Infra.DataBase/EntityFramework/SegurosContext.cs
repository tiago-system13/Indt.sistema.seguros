using Indt.Sistema.Seguros.Infra.DataBase.Models.ContratoAgreggate;
using Indt.Sistema.Seguros.Infra.DataBase.Models.PropostaAgreggate;
using Microsoft.EntityFrameworkCore;

namespace Indt.Sistema.Seguros.Infra.DataBase.EntityFramework
{
    public class SegurosContext : DbContext
    {
        private readonly DbOptions _dbOptions;

        public DbSet<ContratoEntity> Contratos { get; set; }

        public DbSet<PropostaEntity> Propostas { get; set; }

        public DbSet<ParcelaEntity> Parcelas { get; set; }

        public SegurosContext()
        {

        }

        public SegurosContext(DbContextOptions<SegurosContext> options, DbOptions dbOptions) : base(options)
        {
            _dbOptions = dbOptions ?? throw new ArgumentNullException(nameof(dbOptions));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbOptions.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!string.IsNullOrEmpty(_dbOptions.Shema))
                modelBuilder.HasDefaultSchema(_dbOptions.Shema.Replace(".", ""));

            ContratoBuilder.Build(modelBuilder.Entity<ContratoEntity>());
            PropostaBuilder.Build(modelBuilder.Entity<PropostaEntity>());
            ParcelaBuilder.Build(modelBuilder.Entity<ParcelaEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
