using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Application.Interfaces.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        bool HasTitle(string title);
    }
}
