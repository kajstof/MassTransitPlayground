using System.Threading.Tasks;
using Bogann.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Bogann.MyConsumer.Consumers
{
    // TODO: Name of the exchange and queue
    public class KkMySecondConsumer :
        IConsumer<HelloMessage>
    {
        private readonly ILogger<KkMySecondConsumer> _logger;
        public KkMySecondConsumer(ILogger<KkMySecondConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<HelloMessage> context)
        {
            _logger.LogInformation("2: Hello {Name}", context.Message.Name);
            return Task.CompletedTask;
        }
    }
    
    public class KkMySecondConsumerDefinition :
        ConsumerDefinition<KkMySecondConsumer>
    {
        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<KkMySecondConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}
