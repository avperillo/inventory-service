using Inventory.Domain.Aggregates.Items;
using System;
using System.Threading.Tasks;

namespace Inventory.Application.item
{
    public interface IAddItemUseCase
    {
        Task<Item> Create(string name, ItemType type, DateTime expirationDate);
    }
}