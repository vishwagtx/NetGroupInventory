using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Persistent.Repositories
{
    internal class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }

        public bool HasTitle(string title)
        {
            return dbSet.Any(s => s.Title == title);
        }
    }
}
