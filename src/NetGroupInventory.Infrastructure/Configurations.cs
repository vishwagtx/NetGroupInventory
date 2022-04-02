using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetGroupInventory.Application.Interfaces.Clients;
using NetGroupInventory.Application.Interfaces.Rest;
using NetGroupInventory.Infrastructure.Account;
using NetGroupInventory.Infrastructure.Azure;

namespace NetGroupInventory.Infrastructure
{
    public static class Configurations
    {
        public static void AddInfraConfigurations(this IServiceCollection services)
        {
            services.AddSingleton<IFileStorageClient, AzureStorageAccountClient>();

            services.AddScoped<IIdentityServerClient, IdentityServerClient>();
        }
    }
}
