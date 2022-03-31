using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Application.Interfaces.Repositories
{
    public interface IStorageLevelRepository : IRepository<StorageLevel>
    {
        bool HasLevel(string level, string userId);

        Task<IList<StorageLevel>> GetByUserId(string userId);
    }
}
