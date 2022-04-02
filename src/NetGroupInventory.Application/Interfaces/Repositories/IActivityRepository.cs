using NetGroupInventory.Infrastructure.Activities;

namespace NetGroupInventory.Application.Interfaces.Repositories
{
    public interface IActivityRepository
    {
        Task<IList<LatestUserActivity>> GetLatestUserActivity();
    }
}
