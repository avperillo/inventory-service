using Inventory.Domain.Aggregates.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public RemoveItemUseCase(IItemRepository repo)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task ByName(string itemName)
        {
            var item = repo.GetBy(itemName);

            repo.Remove(item);
            await repo.UnitOfWork.SaveChangesAsync();
        }
    }
}
