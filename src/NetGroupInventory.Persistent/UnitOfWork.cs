using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Application.Interfaces.Repositories;
using NetGroupInventory.Persistent.Repositories;

namespace NetGroupInventory.Persistent
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly InventoryDbContext dbContext;

        private IItemCategoryRepository itemCategories;
        private IItemRepository items;
        private IStorageLevelRepository storageLevels;
        private IInventoryRepository inventories;
        private IActivityRepository activities;

        public UnitOfWork(InventoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IItemCategoryRepository ItemCategories => itemCategories ??= new ItemCategoryRepository(dbContext);

        public IItemRepository Items => items ??= new ItemRepository(dbContext);

        public IStorageLevelRepository StorageLevels => storageLevels ??= new StorageLevelRepository(dbContext);

        public IInventoryRepository Inventories => inventories ??= new InventoryRepository(dbContext);

        public IActivityRepository Activities => activities ??= new ActivityRepository(dbContext);


        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
