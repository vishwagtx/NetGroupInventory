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
        private IStoargeLevelRepository stoargeLevels;
        private IInventoryRepository inventories;

        public UnitOfWork(InventoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IItemCategoryRepository ItemCategories => itemCategories ??= new ItemCategoryRepository(dbContext);

        public IItemRepository Items => items ??= new ItemRepository(dbContext);

        public IStoargeLevelRepository StoargeLevels => stoargeLevels ??= new StoargeLevelRepository(dbContext);

        public IInventoryRepository Inventories => inventories ??= new InventoryRepository(dbContext);


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
