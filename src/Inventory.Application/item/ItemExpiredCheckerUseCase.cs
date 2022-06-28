using EventBus.Contracts;
using Inventory.Domain.Aggregates.Items;
using Inventory.Domain.IntegrationEvents.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Inventory.Application.item
{
    public interface IItemExpiredCheckerUseCase
    {
        void Check();
    }

    public class ItemExpiredCheckerUseCase : IItemExpiredCheckerUseCase
    {
        private readonly ILogger<ItemExpiredCheckerUseCase> logger;
        private readonly IItemRepository repo;
        private readonly IEventBus evenBus;

        public ItemExpiredCheckerUseCase(ILogger<ItemExpiredCheckerUseCase> logger, IItemRepository repo, IEventBus evenBus)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this.evenBus = evenBus ?? throw new ArgumentNullException(nameof(evenBus));
        }

        public void Check()
        {
            var items = repo.FindExpired();

            logger.LogInformation("Found expired items [{items}]", string.Join(", ", items.Select(i => i.Id)));

            foreach (var item in items)
            {
                evenBus.Publish(new ItemExpiredIntegrationEvent(item.Id, item.ExpirationDate));
            }
        }
    }
}
