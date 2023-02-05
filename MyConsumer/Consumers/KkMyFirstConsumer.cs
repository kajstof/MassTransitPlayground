using Microsoft.Extensions.Logging;

namespace Bogann.MyConsumer.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    // TODO: Name of the exchange and queue
    public class KkMyFirstConsumer :
        IConsumer<HelloMessage>
    {
        private readonly ILogger<KkMyFirstConsumer> _logger;
        public KkMyFirstConsumer(ILogger<KkMyFirstConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<HelloMessage> context)
        {
            _logger.LogInformation("Hello {Name}", context.Message.Name);
            return Task.CompletedTask;
        }
    }
    
    public class KkMyFirstConsumerDefinition :
        ConsumerDefinition<KkMyFirstConsumer>
    {
        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<KkMyFirstConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}
