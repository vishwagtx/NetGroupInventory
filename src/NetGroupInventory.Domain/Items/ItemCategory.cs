using NetGroupInventory.Domain.Entities;

namespace NetGroupInventory.Domain.Items
{
    public class ItemCategory : IEntity
    {
        public int Id { get; set; }
        public string Category { get; set; } 

        public virtual ICollection<Item> Items { get; set; } 
    }
}
