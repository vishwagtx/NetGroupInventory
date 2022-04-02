using NetGroupInventory.Domain.Entities;
using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Application.Interfaces.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        bool HasTitle(string title, string userId);
        bool HasTitle(string title, string userId, int id);
        Task<IList<Item>> GetByUserId(string userId);
        Task<IList<Item>> GetByKeywordAndUserId(string keyword, string userId);
        Task<Item> GetByIdWithDetails(int id);
        Task<IList<GroupEntity>> GetUserWiseCount();
    }
}
