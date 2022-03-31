using MediatR;
using NetGroupInventory.Application.Items.Commands.CreateItem;
using NetGroupInventory.Application.Storage.Commands.CreateStorageLevel;
using NetGroupInventory.Application.Storage.Queries.GetStorageLevelsForUser;

namespace NetGroupInventory.Service.MediatR
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateStorageLevelCommandHandler),
                typeof(CreateItemCommandHandler),
                typeof(GetStorageLevelsForUserQueryHandler)
                );
        }
    }
}
