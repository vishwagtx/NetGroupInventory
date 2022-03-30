using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Persistent.Repositories
{
    internal class ItemCategoryRepository : Repository<ItemCategory>, IItemCategoryRepository
    {
        public ItemCategoryRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
