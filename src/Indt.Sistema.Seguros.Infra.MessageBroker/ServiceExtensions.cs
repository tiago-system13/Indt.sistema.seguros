using Indt.Sistema.Seguros.Domain.Adapters.Commands;
using Indt.Sistema.Seguros.Domain.Adapters.Producers;
using Indt.Sistema.Seguros.Infra.MessageBroker.Consumers;
using Indt.Sistema.Seguros.Infra.MessageBroker.Producers;
using Indt.Sistema.Seguros.Infra.MessageBroker.Settings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Indt.Sistema.Seguros.Infra.MessageBroker
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMessageBrokerServiceConsumer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitmqServerContratoCiradoConsumer(configuration);       
            return services;
        }

        public static IServiceCollection AddMessageBrokerServiceProducer(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = GetRabbitmqSettings(configuration);          
           
            services.AddRabbitmqServiceContratoCriadoProducer(settings);           
            return services;
        }

        public static void AddRabbitmqServiceContratoCriadoProducer(this IServiceCollection services, RabbitmqServiceSettings serviceSettings)
        {
            
            services.AddMassTransit(x =>
            {                
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseConcurrencyLimit(serviceSettings.ContratoCommand.ConcurrencyLimit);
                    cfg.Host(serviceSettings.ContratoCommand.ConnectionString, h =>
                    {
                        h.RequestedConnectionTimeout(TimeSpan.FromSeconds(serviceSettings.ContratoCommand.OperationTimeout));
                        h.Username(serviceSettings.User);
                        h.Password(serviceSettings.Password);
                    });

                    EndpointConvention.Map<ContratoCriadoCommand>
                    (serviceSettings.ContratoCommand.Queues.CriarContratoCommandV1.GetUrl(serviceSettings.ContratoCommand.ConnectionString));

                    cfg.Message<ContratoCriadoCommand>(message =>
                    {
                        message.SetEntityName(serviceSettings.ContratoCommand.Queues.CriarContratoCommandV1.Name);
                    });
                });
               
            });
            services.AddScoped<IContratoCriadoProducer, ContratoCriadoProducer>();

        }

        public static void AddRabbitmqServerContratoCiradoConsumer(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitmqSetting = GetRabbitmqSettings(configuration);
            services.AddMassTransit<IBusControl>(x =>
            {
                x.AddConsumer<ContratoCriadoConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.UseConcurrencyLimit(rabbitmqSetting.ContratoCommand.ConcurrencyLimit);
                    cfg.Host(rabbitmqSetting.ContratoCommand.ConnectionString, h =>
                    {
                        h.RequestedConnectionTimeout(TimeSpan.FromSeconds(rabbitmqSetting.ContratoCommand.OperationTimeout));
                        h.Username(rabbitmqSetting.User);
                        h.Password(rabbitmqSetting.Password);
                    });

                    cfg.ReceiveEndpoint(rabbitmqSetting.ContratoCommand.Queues.CriarContratoCommandV1.Name, e =>
                    {
                        e.PrefetchCount = rabbitmqSetting.ContratoCommand.Queues.CriarContratoCommandV1.PrefetchCount;
                        e.ConfigureConsumer<ContratoCriadoConsumer>(context);
                        e.UseMessageRetry(r => r.Interval(rabbitmqSetting.Retry.MinimumInterval, rabbitmqSetting.Retry.MaximumInteval));
                        EndpointConvention.Map<ContratoCriadoCommand>(e.InputAddress);
                    });
                });
            });
        }

        private static RabbitmqServiceSettings GetRabbitmqSettings(IConfiguration configuration)
        {
            return configuration.GetSection("RabbitmqServiceSettings").Get<RabbitmqServiceSettings>();
        }
    }
}
