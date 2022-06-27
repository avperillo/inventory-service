using DDD.abstracts;
using Inventory.API.Shared;
using Inventory.Domain.Aggregates.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Controllers.Item.Dtos
{
    public class ItemDto : MapeableDto<ItemDto, Domain.Aggregates.Items.Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemType { get; set; }
        public DateTime ExpirationDate { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.Type,
                src => Enumeration.FromValue<ItemType>(src.ItemType));

            SetCustomMappingsInverse()
                .Map(dest => dest.ItemType,
                src => src.Type.Id);
        }
    }
}
