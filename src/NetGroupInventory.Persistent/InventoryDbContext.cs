using Microsoft.EntityFrameworkCore;
using NetGroupInventory.Domain.Items;
using NetGroupInventory.Domain.Stoarge;
using NetGroupInventory.Persistent.Items;
using NetGroupInventory.Persistent.Storage;

namespace NetGroupInventory.Persistent
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ItemCategory> ItemCategories { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<StorageLevel> StoargeLevels { get; set; }

        public virtual DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ItemCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new StorageLevelConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
        }
    }
}

