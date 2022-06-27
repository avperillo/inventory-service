using Inventory.Application.item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Inventory.API.Controllers.Item
{
    [Route("api/items")]
    public class RemoveItemController : ControllerBase
    {
        private readonly IRemoveItemUseCase useCase;

        public RemoveItemController(IRemoveItemUseCase useCase)
        {
            this.useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveByName ([FromQuery] string name)
        {
            try
            {
                await useCase.ByName(name);

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
