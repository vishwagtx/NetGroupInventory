using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetGroupInventory.Application.Storage.Commands.CreateInventory;
using NetGroupInventory.Application.Storage.Commands.DeleteInventory;
using NetGroupInventory.Application.Storage.Commands.UpdateInventory;
using NetGroupInventory.Application.Storage.Queries.GetInventoriesForUser;
using NetGroupInventory.Application.Storage.Queries.GetInventoryById;

namespace NetGroupInventory.Service.Storage
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoriesController : ControllerBase
    {
        readonly IMediator bus;

        public InventoriesController(IMediator bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateInventoryCommand command)
        {
            return Ok(await bus.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateInventoryCommand command)
        {
            return Ok(await bus.Send(command));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await bus.Send(new DeleteInventoryCommand
            {
                Id = id
            }));
        }

        [HttpGet]
        [Route("search")]
        [Route("search/{keyword}")]
        public async Task<IActionResult> Search(string? keyword)
        {
            return Ok(await bus.Send(new GetInventoriesForUserQuery
            {
                Keyword = keyword
            }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await bus.Send(new GetInventoryByIdQuery
            {
                Id = id
            }));
        }
    }
}
