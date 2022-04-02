using Microsoft.EntityFrameworkCore;
using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Domain.Entities;
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

        public bool HasLevel(string level, string userId, int id)
        {
            return dbSet.Any(s => s.Level == level && s.CreatedBy == userId && s.Id != id);
        }

        public async Task<IList<StorageLevel>> GetByUserId(string userId)
        {
            return await dbSet.Where(s => s.CreatedBy == userId).ToListAsync();
        }

        public async Task<IList<StorageLevel>> GetByKeywordAndUserId(string keyword, string userId)
        {
            return await dbSet.Where(s => s.CreatedBy == userId && (s.Level.Contains(keyword) || s.Description.Contains(keyword))).ToListAsync();
        }

        public async Task<IList<GroupEntity>> GetUserWiseCount()
        {
            var levelGroup = await dbSet.GroupBy(g => g.CreatedBy).Select(s => new GroupEntity {
                Key = s.Key, 
                Count = s.Count()
            }).ToListAsync();

            return levelGroup;
        }
    }
}
