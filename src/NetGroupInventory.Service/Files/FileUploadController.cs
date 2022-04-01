using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetGroupInventory.Application.Files.UploadFile;

namespace NetGroupInventory.Service.Files
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileUploadController : ControllerBase
    {
        readonly IMediator bus;

        public FileUploadController(IMediator bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(string? container = "images")
        {
            var file = Request.Form.Files[0];

            return Ok(await bus.Send(new UploadFileCommand
            {
                FileName = file.FileName,
                FileStream = file.OpenReadStream(),
                Container = container
            }));
        }
    }
}
