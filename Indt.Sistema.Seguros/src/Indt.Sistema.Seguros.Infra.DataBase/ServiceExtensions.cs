using Indt.Sistema.Seguros.Infra.DataBase.EntityFramework;
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
            
        }
    }
}
