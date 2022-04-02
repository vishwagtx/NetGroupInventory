using NetGroupInventory.Domain.Account;
using RestEase;

namespace NetGroupInventory.Application.Interfaces.Rest
{
    public interface IIdentityServerClient
    {
        [Get("api/Users")]
        Task<IList<UserLite>> GetUsers();
    }
}
