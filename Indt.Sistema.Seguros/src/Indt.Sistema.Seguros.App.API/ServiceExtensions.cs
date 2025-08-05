using Indt.Sistema.Seguros.App.API.Propostas.CriarProposta;
using Indt.Sistema.Seguros.Domain.Adapters;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Indt.Sistema.Seguros.App.API
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CriarPropostaRequest, CriarPropostaResponse>>(x =>
            new CriarPropostaHandler(x.GetRequiredService<IPropostaRepository>(), x.GetRequiredService<Domain.Shared.Notifications.INotification>()));
        }
    }
}
