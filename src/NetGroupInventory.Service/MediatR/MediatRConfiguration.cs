using MediatR;
using NetGroupInventory.Application.Items.Commands.CreateItem;
using NetGroupInventory.Application.Items.Commands.DeleteItem;
using NetGroupInventory.Application.Items.Commands.UpdateItem;
using NetGroupInventory.Application.Items.Queries.GetItemCategories;
using NetGroupInventory.Application.Storage.Commands.CreateStorageLevel;
using NetGroupInventory.Application.Storage.Commands.UpdateStorageLevel;
using NetGroupInventory.Application.Storage.Queries.GetStorageLevelsForUser;

namespace NetGroupInventory.Service.MediatR
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateStorageLevelCommandHandler),
                typeof(CreateItemCommandHandler),
                typeof(GetStorageLevelsForUserQueryHandler),
                typeof(UpdateStorageLevelCommandHandler),
                typeof(UpdateItemCommandHandler),
                typeof(DeleteItemCommandHandler),
                typeof(GetItemCategoriesQueryHandler)
                );
        }
    }
}
