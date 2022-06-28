using Inventory.Domain.Aggregates.Items;
using System;

namespace Inventory.Infrastructure.Seed
{
    public static class DataSeed
    {
        public static void Seed(InventoryContext context)
        {
            context.Items.Add(new Item("Seed 1", new DateTime(2022, 6, 27), ItemType.Unknow));
            context.Items.Add(new Item("Seed 2", new DateTime(2022, 4, 27), ItemType.Unknow));
            context.Items.Add(new Item("Seed 3", new DateTime(2022, 7, 27), ItemType.Unknow));

            context.SaveChanges();
        }
    }
}
