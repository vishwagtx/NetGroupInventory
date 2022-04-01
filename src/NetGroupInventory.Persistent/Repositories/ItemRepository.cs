using Microsoft.EntityFrameworkCore;
using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Persistent.Repositories
{
    internal class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }

        public bool HasTitle(string title, string userId)
        {
            return dbSet.Any(i => i.Title == title && i.CreatedBy == userId);
        }

        public bool HasTitle(string title, string userId, int id)
        {
            return dbSet.Any(i => i.Title == title && i.CreatedBy == userId && i.Id != id);
        }

        public async Task<IList<Item>> GetByUserId(string userId)
        {
            return await dbSet.Include(i => i.ItemCategory).Where(i => i.CreatedBy == userId).ToListAsync();
        }

        public async Task<IList<Item>> GetByKeywordAndUserId(string keyword, string userId)
        {
            return await dbSet.Include(i => i.ItemCategory).Where(i => i.CreatedBy == userId &&
            (i.Title.Contains(keyword) || i.Description.Contains(keyword) || i.ItemCategory.Category.Contains(keyword))).ToListAsync();
        }

        public async Task<Item> GetByIdWithDetails(int id)
        {
            return await dbSet.Include(i => i.ItemCategory).FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
