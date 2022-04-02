using Microsoft.EntityFrameworkCore;
using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Infrastructure.Activities;

namespace NetGroupInventory.Persistent.Repositories
{
    internal class ActivityRepository : IActivityRepository
    {
        readonly InventoryDbContext inventoryDb;

        public ActivityRepository(InventoryDbContext dbContext)
        {
            inventoryDb = dbContext;
        }


        public async Task<IList<LatestUserActivity>> GetLatestUserActivity()
        {
            var result = await inventoryDb.StoargeLevels.Select(s => new
            {
                UserId = s.CreatedBy,
                LastActivityDateTime = s.ModifiedDateTime.HasValue ? s.ModifiedDateTime.Value : s.CreatedDateTime
            }).Union(inventoryDb.Items.Select(s => new
            {
                UserId = s.CreatedBy,
                LastActivityDateTime = s.ModifiedDateTime.HasValue ? s.ModifiedDateTime.Value : s.CreatedDateTime
            })).Union(inventoryDb.Inventories.Select(s => new
            {
                UserId = s.CreatedBy,
                LastActivityDateTime = s.ModifiedDateTime.HasValue ? s.ModifiedDateTime.Value : s.CreatedDateTime,
            })).GroupBy(g => g.UserId).Select(s => new LatestUserActivity
            {
                UserId = s.Key.ToString(),
                LastActivityDateTime = s.Max(sc => sc.LastActivityDateTime)
            }).OrderByDescending(o => o.LastActivityDateTime)
             .Take(5).ToListAsync();

            return result;
        }
    }
}
