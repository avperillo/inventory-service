using DDD.abstracts;
using System;

namespace Inventory.Domain.Aggregates.Items
{
    public class Item : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public ItemType Type { get; private set; } = ItemType.Unknow;

        public Item(string name, DateTime expirationDate, ItemType type)
        {
            EnsureNameIsNotNullOrEmpty(name);

            Name = name;
            ExpirationDate = expirationDate;
            Type = type;
        }

        private static void EnsureNameIsNotNullOrEmpty(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }
        }
    }
}
