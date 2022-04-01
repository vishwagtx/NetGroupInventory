namespace NetGroupInventory.Application.Storage.Commands.Dtos
{
    public abstract class BaseInventoryDto
    {
        public int StorageLevelId { get; set; }
        public int ItemId { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
        public int? Quantity { get; set; }
    }
}
