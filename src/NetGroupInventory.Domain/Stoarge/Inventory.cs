using NetGroupInventory.Domain.Entities;
using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Domain.Stoarge
{
    public class Inventory : IEntity, ITraceEntity
    {
        public int Id { get; set; }
        public int StorageLevelId { get; set; }
        public int ItemId { get; set; }
        public string SerialNumber { get; set; } 
        public string Note { get; set; }
        public int? Quantity { get; set; }

        public string CreatedBy { get; set; } 
        public DateTimeOffset CreatedDateTime { get; set; } 
        public string ModifiedBy { get; set; } 
        public DateTimeOffset? ModifiedDateTime { get; set; }


        public virtual Item Item { get; set; } 
        public virtual StorageLevel StorageLevel { get; set; } 
    }
}
