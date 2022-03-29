using NetGroupInventory.Domain.Entities;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Domain.Items
{
    public class Item : IEntity, ITraceEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string ImageUrl { get; set; } 

        public string CreatedBy { get; set; } 
        public DateTimeOffset CreatedDateTime { get; set; }
        public string ModifiedBy { get; set; } 
        public DateTimeOffset? ModifiedDateTime { get; set; }


        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ICollection<Inventory> InventoryItems { get; set; }
    }
}
