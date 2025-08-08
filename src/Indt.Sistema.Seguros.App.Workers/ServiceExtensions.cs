using Indt.Sistema.Seguros.App.Workers.CriarContrato;
using Indt.Sistema.Seguros.Domain.Adapters.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace Indt.Sistema.Seguros.App.Workers
{
    public static class ServiceExtensions
    {
        public static void AddDispatchers(this IServiceCollection services)
        {
            services.AddScoped<ICriarContratoDispatcher, CriarContratoDispatcher>();
        }
    }
}
