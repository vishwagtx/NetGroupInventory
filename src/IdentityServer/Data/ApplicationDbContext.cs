using IdentityServer.Constants;
using IdentityServer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace IdentityServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private Guid roleId = Guid.Parse("e0bb734c-ee59-45f2-880e-1516677d1e7b");

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<IdentityRole>().HasData(new IdentityRole[]
            //{
            //    new()
            //    {
            //        Id = roleId.ToString(),
            //        Name = Role.Administrator,
            //        NormalizedName = Role.Administrator.ToUpper()
            //    }
            //}); 
        }
    }
}
