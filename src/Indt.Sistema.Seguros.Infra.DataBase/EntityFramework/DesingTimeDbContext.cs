using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Indt.Sistema.Seguros.Infra.DataBase.EntityFramework
{
    internal class DesingTimeDbContext : IDesignTimeDbContextFactory<SegurosContext>
    {
        public SegurosContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var schema = "idtsistemaseguro";

            var builder = new DbContextOptionsBuilder<SegurosContext>();
            builder.UseSqlServer(connectionString);

            return new SegurosContext(builder.Options, new DbOptions(connectionString, schema));

        }
    }
}
