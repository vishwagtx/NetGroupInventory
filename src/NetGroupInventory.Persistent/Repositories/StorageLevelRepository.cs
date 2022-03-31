using Microsoft.EntityFrameworkCore;
using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Persistent.Repositories
{
    internal class StorageLevelRepository : Repository<StorageLevel>, IStorageLevelRepository
    {
        public StorageLevelRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }

        public bool HasLevel(string level, string userId)
        {
            return dbSet.Any(s => s.Level == level && s.CreatedBy == userId);
        }

        public async Task<IList<StorageLevel>> GetByUserId(string userId)
        {
            return await dbSet.Where(s => s.CreatedBy == userId).ToListAsync();
        }
    }
}
