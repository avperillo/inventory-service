using DDD.abstracts;
using Inventory.API.Controllers.Item.Dtos;
using Inventory.Application.item;
using Inventory.Domain.Aggregates.Items;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Controllers.Item
{
    [Route("api/items")]
    [ApiController]
    public class AddItemController : ControllerBase
    {
        private readonly IAddItemUseCase useCase;

        public AddItemController(IAddItemUseCase useCase)
        {
            this.useCase = useCase ?? throw new System.ArgumentNullException(nameof(useCase));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItem([FromBody] AddItemDto cmd)
        {
            EnsureItemTypeAreCorrect(cmd.ItemType);

            var item = await useCase.Create(cmd.Name, Enumeration.FromValue<ItemType>(cmd.ItemType), cmd.ExpirationDate);

            return Ok(item.Adapt<ItemDto>());
        }

        private static void EnsureItemTypeAreCorrect(int itemType)
        {
            if (!Enumeration.GetAll<ItemType>().Any(e => e.Id == itemType)) throw new ArgumentException($"'{nameof(itemType)}' cannot be null or empty.", nameof(itemType));
        }
    }
}
