﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetGroupInventory.Application.Stoarge.Commands.CreateStoargeLevel;

namespace NetGroupInventory.Service.Stoarge
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoargeLevelsController : ControllerBase
    {
        readonly IMediator bus;

        public StoargeLevelsController(IMediator bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateStoargeLevelCommand command)
        {
            return Ok(await bus.Send(command));
        }
    }
}