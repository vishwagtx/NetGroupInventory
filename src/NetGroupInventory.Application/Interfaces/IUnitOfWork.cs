using NetGroupInventory.Application.Interfaces.Repositories;

namespace NetGroupInventory.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IItemCategoryRepository ItemCategories { get; }
        IItemRepository Items { get; }
        IStoargeLevelRepository StoargeLevels { get; }
        IInventoryRepository Inventories { get; }

        void Save();

        Task SaveAsync();
    }
}
