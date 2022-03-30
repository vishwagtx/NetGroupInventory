using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetGroupInventory.Application.Items.Commands.CreateItem;

namespace NetGroupInventory.Service.Items
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        readonly IMediator bus;

        public ItemsController(IMediator bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateItemCommand command)
        {
            return Ok(await bus.Send(command));
        }
    }
}
