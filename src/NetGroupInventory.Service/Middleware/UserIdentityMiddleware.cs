using NetGroupInventory.Application.Common.Dtos;
using System.Security.Claims;

namespace NetGroupInventory.Service.Middleware
{
    public class UserIdentityMiddleware
    {
        private readonly RequestDelegate _next;

        public UserIdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IUserIdentity userIdentity)
        {
            if (httpContext.User?.Identity?.IsAuthenticated ?? false)
            {
                userIdentity.Name = httpContext.User.Identity.Name;
                userIdentity.UserName = httpContext.User.Claims.FirstOrDefault(x => x.Type == "userName")?.Value;
                userIdentity.Identifier = httpContext.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
                userIdentity.AccessToken = httpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString().Replace("Bearer ", "");
                userIdentity.Roles = httpContext.User.Claims.Where(t => t.Type == ClaimTypes.Role || t.Type == "role").Select(s => s.Value).ToList();
                userIdentity.Email = httpContext.User.Claims.FirstOrDefault(x => x.Type == "email")?.Value;
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UserIdentityMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserIdentityMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserIdentityMiddleware>();
        }
    }
}
