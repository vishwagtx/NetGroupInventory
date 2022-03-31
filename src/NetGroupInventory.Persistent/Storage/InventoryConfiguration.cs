using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Persistent.Storage
{
    internal class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.SerialNumber).HasMaxLength(150);
            builder.Property(p => p.Note).HasMaxLength(3000);

            builder.Property(p => p.CreatedBy).HasMaxLength(40).IsRequired();
            builder.Property(p => p.ModifiedBy).HasMaxLength(40);

            builder.HasIndex(p => p.CreatedBy);

            builder.HasOne(p => p.StorageLevel).WithMany(m => m.InventoryItems).HasForeignKey(f => f.StorageLevelId);
            builder.HasOne(p => p.Item).WithMany(m => m.InventoryItems).HasForeignKey(f => f.ItemId);
        }
    }
}
