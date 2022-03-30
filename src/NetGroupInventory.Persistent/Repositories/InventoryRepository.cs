using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Persistent.Repositories
{
    internal class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
