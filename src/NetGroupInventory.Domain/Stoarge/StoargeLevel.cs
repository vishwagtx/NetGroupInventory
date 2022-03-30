using NetGroupInventory.Domain.Entities;

namespace NetGroupInventory.Domain.Stoarge
{
    public class StoargeLevel : IEntity, ITraceEntity
    {
        public int Id { get; set; }
        public string Level { get; set; } 
        public string Description { get; set; } 

        public string CreatedBy { get; set; } 
        public DateTimeOffset CreatedDateTime { get; set; } 
        public string ModifiedBy { get; set; } 
        public DateTimeOffset? ModifiedDateTime { get; set; }


        public virtual ICollection<Inventory> InventoryItems { get; set; }
    }
}
