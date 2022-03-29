using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
