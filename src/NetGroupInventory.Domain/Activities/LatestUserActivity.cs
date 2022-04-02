namespace NetGroupInventory.Infrastructure.Activities
{
    public class LatestUserActivity
    {
        public string UserId { get; set; }
        public DateTimeOffset LastActivityDateTime { get; set; }
    }
}
