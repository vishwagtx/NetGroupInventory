using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetGroupInventory.Application.Storage.Commands.CreateStorageLevel;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await bus.Send(new GetStorageLevelsForUserQuery()));
        }
    }
}
