using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Application.Interfaces.Repositories
{
    public interface IStorageLevelRepository : IRepository<StorageLevel>
    {
        bool HasLevel(string level, string userId);

        bool HasLevel(string level, string userId, int id);

        Task<IList<StorageLevel>> GetByUserId(string userId);

        Task<IList<StorageLevel>> GetByKeywordAndUserId(string keyword, string userId);
    }
}
