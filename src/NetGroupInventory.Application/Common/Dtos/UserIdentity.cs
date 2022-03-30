
namespace NetGroupInventory.Application.Common.Dtos
{
    public interface IUserIdentity
    {
        string UserName { get; set; }
        string AccessToken { get; set; }
        string Identifier { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        List<string> Roles { get; set; }
    }

    public class UserIdentity : IUserIdentity
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string Identifier { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
