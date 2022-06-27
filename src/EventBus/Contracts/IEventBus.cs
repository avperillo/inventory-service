using System;

namespace EventBus.Contracts
{
    public interface IEventBus
    {
        void Publish(IntegrationEvent @event);
    }
}
