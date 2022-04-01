using NetGroupInventory.Application.Common.Dtos;

namespace NetGroupInventory.Application.Storage.Queries.Dtos
{
    public class ViewInventoryDto
    {
        public int Id { get; set; }
        public int StorageLevelId { get; set; }
        public string StorageLevel { get; set; }
        public int ItemId { get; set; }
        public ItemDto Item { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
        public int? Quantity { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
}
