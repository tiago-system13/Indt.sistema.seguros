using Indt.Sistema.Seguros.Domain.Shared.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Indt.Sistema.Seguros.Domain
{
    public static class ServiceExtensions
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddTransient<INotification, Notification>();
        }
    }
}
