using EventBus;
using System;

namespace Inventory.Domain.IntegrationEvents.Events
{
    public record ItemExpiredIntegrationEvent : IntegrationEvent
    {
        public int ItemId { get; }
        public DateTime DateTime { get; }

        public ItemExpiredIntegrationEvent(int itemId, DateTime dateTime)
        {
            ItemId = itemId;
            DateTime = dateTime;
        }
    }
}
