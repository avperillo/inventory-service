using DDD.abstracts;
using Inventory.Domain.Aggregates.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Item GetBy(string name)
        {
            return context.Items.Single(i => i.Name == name);
        }

        public void Remove(Item item)
        {
            context.Items.Remove(item);
        }

    }
}
