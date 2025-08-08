namespace Indt.Sistema.Seguros.Infra.MessageBroker.Settings
{
    public class RabbitmqServiceSettings
    {        
        public RabbitRetrySettings Retry { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public RabbitServiceApplicationSettings ContratoCommand { get; set; }
    }
}
