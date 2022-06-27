using Inventory.Domain.Aggregates.Items;
using System;
using System.Threading.Tasks;

namespace Inventory.Application.item
{
    public interface IAddItemUseCase
    {
        Task<Item> Create(string name, ItemType type, DateTime expirationDate);
    }

    public class AddItemUseCase : IAddItemUseCase
    {
        private readonly IItemRepository repo;

        public AddItemUseCase(IItemRepository repo)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<Item> Create(string name, ItemType type, DateTime expirationDate)
        {
            var item = new Item(name, expirationDate, type);

            repo.Add(item);
            await repo.UnitOfWork.SaveChangesAsync();
            return item;
        }
    }
}
