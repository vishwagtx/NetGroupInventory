using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetGroupInventory.Application.Statistics.GetStatistic;

namespace NetGroupInventory.Service.Statistics
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class StatisticsController : ControllerBase
    {
        readonly IMediator bus;

        public StatisticsController(IMediator bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await bus.Send(new GetStatisticQuery()));
        }
    }
}
