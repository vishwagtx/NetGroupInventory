using Microsoft.Extensions.Configuration;
using NetGroupInventory.Application.Interfaces.Rest;
using NetGroupInventory.Domain.Account;
using RestEase;

namespace NetGroupInventory.Infrastructure.Account
{
    public class IdentityServerClient : IIdentityServerClient
    {
        readonly IIdentityServerClient client;

        public IdentityServerClient(IConfiguration configuration, IHttpClientFactory factory)
        {
            var httpClient = factory.CreateClient("authClient");
            httpClient.BaseAddress = new Uri(configuration["IdentityServerUrl"]);
            client = RestClient.For<IIdentityServerClient>(httpClient);
        }

        public async Task<IList<UserLite>> GetUsers()
        {
            return await client.GetUsers();
        }
    }
}
