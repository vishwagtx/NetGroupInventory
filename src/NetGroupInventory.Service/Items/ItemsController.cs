using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetGroupInventory.Application.Items.Commands.CreateItem;
using NetGroupInventory.Application.Items.Commands.UpdateItem;
using NetGroupInventory.Application.Items.Queries.GetItemsForUser;
using NetGroupInventory.Application.Storage.Commands.DeleteStorageLevel;

namespace NetGroupInventory.Service.Items
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPut]
        public async Task<IActionResult> Put(UpdateItemCommand command)
        {
            return Ok(await bus.Send(command));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await bus.Send(new DeleteStorageLevelCommand
            {
                Id = id
            }));
        }

        [HttpGet]
        [Route("search")]
        [Route("search/{keyword}")]
        public async Task<IActionResult> Get(string? keyword)
        {
            return Ok(await bus.Send(new GetItemsForUserQuery
            {
                Keyword = keyword
            }));
        }
    }
}
