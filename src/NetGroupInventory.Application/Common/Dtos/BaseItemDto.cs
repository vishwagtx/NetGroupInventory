namespace NetGroupInventory.Application.Common.Dtos
{
    public abstract class BaseItemDto
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ItemDto : BaseItemDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
    }
}
