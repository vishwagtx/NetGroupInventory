namespace NetGroupInventory.Application.Items.Commands.Dtos
{
    public abstract class BaseItemDto
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
