using Microsoft.EntityFrameworkCore;
using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Persistent.Repositories
{
    internal class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(InventoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Inventory>> GetByUserId(string userId)
        {
            return await dbSet.Include(i => i.Item)
            .ThenInclude(i => i.ItemCategory)
            .Include(i => i.StorageLevel).Where(i => i.CreatedBy == userId).ToListAsync();
        }

        public async Task<IList<Inventory>> GetByKeywordAndUserId(string keyword, string userId)
        {
            return await dbSet.Include(i => i.Item)
            .ThenInclude(i => i.ItemCategory)
            .Include(i => i.StorageLevel)
            .Where(i => i.CreatedBy == userId &&
            (i.Item.Title.Contains(keyword) || i.Item.Description.Contains(keyword) || i.Item.ItemCategory.Category.Contains(keyword) ||
             i.StorageLevel.Level.Contains(keyword) || i.Note.Contains(keyword) || i.SerialNumber.Contains(keyword) || i.Quantity.ToString().Contains(keyword)
            )).ToListAsync();
        }
    }
}
