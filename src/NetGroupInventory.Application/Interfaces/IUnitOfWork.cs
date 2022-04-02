using NetGroupInventory.Application.Interfaces.Repositories;

namespace NetGroupInventory.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IItemCategoryRepository ItemCategories { get; }
        IItemRepository Items { get; }
        IStorageLevelRepository StorageLevels { get; }
        IInventoryRepository Inventories { get; }
        IActivityRepository Activities { get; }

        void Save();

        Task SaveAsync();
    }
}
