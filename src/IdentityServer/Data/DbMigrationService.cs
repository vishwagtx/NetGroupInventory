using IdentityServer.Constants;
using IdentityServer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace IdentityServer.Data
{
    public static class DbMigrationService
    {
        public static void AddDbMigrate(this IServiceCollection service)
        {
            var sp = service.BuildServiceProvider();

            var identityContext = sp.GetService<ApplicationDbContext>();
            identityContext.Database.Migrate();

            Migrate(sp, identityContext).Wait();
        }

        private static async Task Migrate(ServiceProvider sp, ApplicationDbContext identityContext)
        {
            if (identityContext.Roles.CountAsync().Result == 0)
            {
                var roleManager = sp.GetService<RoleManager<IdentityRole>>();

                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = Role.Administrator
                });          
            }

            if (identityContext.Users.CountAsync().Result == 0)
            {
                var userManager = sp.GetService<UserManager<ApplicationUser>>();

                await userManager.CreateAsync(new()
                {
                    Name = "Admin User",
                    UserName = "admin@test.com",
                    Email = "admin@test.com",                   

                }, "1qaz!QAZ");

                var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == "admin@test.com");

                userManager.AddToRoleAsync(user, Role.Administrator).Wait();
                await userManager.UpdateAsync(user);
            }
        }
    }
}
