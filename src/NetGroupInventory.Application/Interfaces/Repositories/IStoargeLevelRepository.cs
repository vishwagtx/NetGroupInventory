using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Application.Interfaces.Repositories
{
    public interface IStoargeLevelRepository : IRepository<StoargeLevel>
    {
        bool HasLevel(string level);
    }
}
