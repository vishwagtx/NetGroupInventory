using IdentityModel;
using IdentityServer.Data.Entities;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.Middleware
{
    public class AspNetIdentityProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AspNetIdentityProfileService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await userManager.GetUserAsync(context.Subject);

            var claims = new List<Claim>() {
               new Claim(ClaimTypes.Name, user.Name),
               new Claim(JwtClaimTypes.Name, user.Name),
               new Claim("userName", user.UserName),
               new Claim(JwtClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.Email, user.UserName),
            };

            var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);

            context.IssuedClaims.AddRange(claims);
            context.IssuedClaims.AddRange(roleClaims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }
    }
}
