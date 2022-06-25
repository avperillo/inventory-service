using DDD.abstracts;
using Inventory.Domain.Aggregates.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Repositories
{

    public class ItemRepository : IItemRepository
    {
        private readonly InventoryContext context;

        public IUnitOfWork UnitOfWork => context;

        public ItemRepository(InventoryContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Item Add(Item item)
        {
            return context.Items.Add(item).Entity;
        }

        public async Task<Item> GetBy(int id)
        {
            return await context.Items.FindAsync(id);
        }

        public void Remove(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
