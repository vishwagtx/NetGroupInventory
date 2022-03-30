using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Persistent.Repositories
{
    internal class StoargeLevelRepository : Repository<StoargeLevel>, IStoargeLevelRepository
    {
        public StoargeLevelRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }

        public bool HasLevel(string level)
        {
            return dbSet.Any(s => s.Level == level);
        }
    }
}
