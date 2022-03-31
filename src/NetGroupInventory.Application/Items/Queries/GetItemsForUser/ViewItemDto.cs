namespace NetGroupInventory.Application.Items.Queries.GetItemsForUser
{
    public class ViewItemDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
}
