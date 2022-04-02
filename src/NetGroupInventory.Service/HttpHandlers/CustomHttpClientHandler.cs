using NetGroupInventory.Application.Common.Dtos;

namespace NetGroupInventory.Service.HttpHandlers
{
    public class CustomHttpClientHandler : DelegatingHandler
    {
        readonly IHttpContextAccessor httpContextAccessor;

        public CustomHttpClientHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var serviceProvider = httpContextAccessor.HttpContext.RequestServices;
            IUserIdentity identity = serviceProvider.GetRequiredService<IUserIdentity>();

            if (!string.IsNullOrEmpty(identity.AccessToken))
                request.Headers.Add("Authorization", "Bearer " + identity.AccessToken);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
