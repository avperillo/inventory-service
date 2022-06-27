using EventBus;

namespace Inventory.Domain.IntegrationEvents.Events
{
    public record ItemRemovedIntegrationEvent : IntegrationEvent
    {
        public int ItemId { get; }

        public ItemRemovedIntegrationEvent(int itemId)
        {
            ItemId = itemId;
        }
    }
}
