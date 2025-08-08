using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks;
using Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate;
using Indt.Sistema.Seguros.Infra.DataBase.EntityFramework;
using Indt.Sistema.Seguros.Infra.DataBase.Models.ContratoAgreggate;
using Indt.Sistema.Seguros.Infra.DataBase.Models.PropostaAgreggate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Indt.Sistema.Seguros.Infra.DataBase
{
    public static class ServiceExtensions
    {
        public static void AddSqlServerProvider(this IServiceCollection services, DbOptions dbOptions)
        {
            services.AddDbContext<SegurosContext>(options =>
            {
                options.UseSqlServer(dbOptions.ConnectionString);
            }, ServiceLifetime.Scoped);

            var dbContextBuilder = new DbContextOptionsBuilder<SegurosContext>().UseSqlServer(dbOptions.ConnectionString);
            services.AddSingleton(dbContextBuilder.Options);
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IPropostaRepository, PropostaRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
