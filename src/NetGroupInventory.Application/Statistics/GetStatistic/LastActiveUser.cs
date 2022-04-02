namespace NetGroupInventory.Application.Statistics.GetStatistic
{
    public class LastActiveUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTimeOffset LastActiveDateTime { get; set; }
    }
}
