namespace NetGroupInventory.Application.Storage.Queries.GetStorageLevelsForUser
{
    public class ViewStorageLevelDto
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
}
