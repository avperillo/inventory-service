using DDD.abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Domain.Aggregates.Items
{
    public interface IItemRepository : IRepository<Item>
    {
        Item Add(Item item);
        void Remove(Item item);
        Task<Item> GetBy(int id);
        Item GetBy(string name);
        IEnumerable<Item> FindExpired();
    }
}
