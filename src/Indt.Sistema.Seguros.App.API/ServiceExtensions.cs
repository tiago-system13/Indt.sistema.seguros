using Indt.Sistema.Seguros.App.API.Contratos.ListarContratos;
using Indt.Sistema.Seguros.App.API.Propostas.AlterarStatusProposta;
using Indt.Sistema.Seguros.App.API.Propostas.CriarProposta;
using Indt.Sistema.Seguros.App.API.Propostas.ListarPropostas;
using Indt.Sistema.Seguros.Domain.Adapters.Producers;
using Indt.Sistema.Seguros.Domain.Adapters.Repository;
using Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Indt.Sistema.Seguros.App.API
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
           services.AddTransient<IRequestHandler<CriarPropostaRequest, CriarPropostaResponse>>(x =>
            new CriarPropostaHandler(x.GetRequiredService<IPropostaRepository>(), x.GetRequiredService<Domain.Shared.Notifications.INotification>(), x.GetRequiredService<IUnitOfWork>()));

            services.AddTransient<IRequestHandler<AlterarStatusPropostaRequest, AlterarStatusPropostaResponse>>(x =>
            new AlterarStatusPropostaHandler(x.GetRequiredService<IPropostaRepository>(), x.GetRequiredService<IContratoCriadoProducer>(), x.GetRequiredService<IUnitOfWork>(), x.GetRequiredService<Domain.Shared.Notifications.INotification>()));

            services.AddTransient<IRequestHandler<ListarPropostasRequest, ListarPropostasResponse>>(x =>
            new ListarPropostasHandler(x.GetRequiredService<IPropostaRepository>()));

            services.AddTransient<IRequestHandler<ListarContratosRequest, ListarContratosResponse>>(x =>
           new ListarContratosHandler(x.GetRequiredService<IContratoRepository>()));
        }
    }
}
