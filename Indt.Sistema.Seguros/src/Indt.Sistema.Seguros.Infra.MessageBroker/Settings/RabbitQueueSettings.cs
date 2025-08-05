using System;

namespace Indt.Sistema.Seguros.Infra.MessageBroker.Settings
{
    public class RabbitQueueSettings
    {
        public string Name { get; set; }

        public ushort PrefetchCount { get; set; }

        public Uri GetUrl(string host)
        {
            return new Uri($"{host}/{Name}");
        }
    }
}
