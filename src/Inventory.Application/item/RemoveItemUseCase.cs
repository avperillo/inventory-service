using EventBus.Contracts;
using Inventory.Domain.Aggregates.Items;
using Inventory.Domain.IntegrationEvents;
using Inventory.Domain.IntegrationEvents.Events;
using System;
using System.Threading.Tasks;

namespace Inventory.Application.item
{
    public interface IRemoveItemUseCase
    {
        Task ByName(string itemName);
    }

    public class RemoveItemUseCase : IRemoveItemUseCase
    {
        private readonly IItemRepository repo;
        private readonly IEventBus eventBus;

        public RemoveItemUseCase(IItemRepository repo, IEventBus eventBus)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task ByName(string itemName)
        {
            var item = repo.GetBy(itemName);

            repo.Remove(item);
            await repo.UnitOfWork.SaveChangesAsync();

            eventBus.Publish(new ItemRemovedIntegrationEvent(item.Id));
        }
    }
}
