using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetGroupInventory.Application.Storage.Commands.CreateStorageLevel;
using NetGroupInventory.Application.Storage.Commands.DeleteStorageLevel;
using NetGroupInventory.Application.Storage.Commands.UpdateStorageLevel;
using NetGroupInventory.Application.Storage.Queries.GetStorageLevelsForUser;

namespace NetGroupInventory.Service.Storage
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StorageLevelsController : ControllerBase
    {
        readonly IMediator bus;

        public StorageLevelsController(IMediator bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateStorageLevelCommand command)
        {
            return Ok(await bus.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateStorageLevelCommand command)
        {
            return Ok(await bus.Send(command));
        }

        [HttpGet]
        [Route("search")]
        [Route("search/{keyword}")]
        public async Task<IActionResult> Get(string? keyword)
        {
            return Ok(await bus.Send(new GetStorageLevelsForUserQuery
            {
                Keyword = keyword
            }));
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
    }
}
