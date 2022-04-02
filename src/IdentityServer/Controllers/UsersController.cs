using IdentityServer.Constants;
using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles = Role.Administrator)]
        public async Task<IActionResult> Get()
        {
            var users = await dbContext.Users.Select(s => new UserLite
            {
                Id = s.Id,
                UserName = s.UserName,
                Name = s.Name,
                Email = s.Email
            }).ToListAsync();

            return Ok(users);
        }
    }
}
