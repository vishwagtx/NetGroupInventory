namespace NetGroupInventory.Application.Statistics.GetStatistic
{
    public class UserStatisticDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int StorageLevelCount { get; set; }
        public int ItemCount { get; set; }
        public int InventoryCount { get; set; }
    }
}
