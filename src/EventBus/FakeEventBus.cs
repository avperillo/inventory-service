using EventBus.Contracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EventBus
{
    public class FakeEventBus : IEventBus
    {
        private readonly ILogger<FakeEventBus> logger;

        public FakeEventBus(ILogger<FakeEventBus> logger)
        {
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public void Publish(IntegrationEvent @event)
        {
            logger.LogInformation("Integration event was published [{eventType}]: {eventValue}", @event.GetType().Name, JsonConvert.SerializeObject(@event));

            // here would be the code to publish in infrastructure artifact, for example, RabbitMQ.
        }
    }
}
