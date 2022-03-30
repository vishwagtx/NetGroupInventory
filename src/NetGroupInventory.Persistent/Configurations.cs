using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetGroupInventory.Application.Interfaces;

namespace NetGroupInventory.Persistent
{
    public static class Configurations
    {
        public static void AddEFConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionString"];

            services.AddDbContext<InventoryDbContext>(opts =>
             opts.UseSqlServer(connectionString)
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
