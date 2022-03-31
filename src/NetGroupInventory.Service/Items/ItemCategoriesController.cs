using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetGroupInventory.Application.Items.Queries.GetItemCategories;

namespace NetGroupInventory.Service.Items
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoriesController : ControllerBase
    {
        readonly IMediator bus;

        public ItemCategoriesController(IMediator bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await bus.Send(new GetItemCategoriesQuery()));
        }
    }
}
