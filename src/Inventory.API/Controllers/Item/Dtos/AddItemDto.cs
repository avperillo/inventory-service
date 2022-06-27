using System;

namespace Inventory.API.Controllers.Item.Dtos
{
    public class AddItemDto
    {
        public string Name { get; set; }
        public int ItemType { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
