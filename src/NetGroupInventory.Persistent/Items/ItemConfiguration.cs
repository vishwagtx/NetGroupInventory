using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Persistent.Items
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(5000);
            builder.Property(p => p.ImageUrl).HasMaxLength(2000);
            builder.Property(p => p.CreatedBy).HasMaxLength(40).IsRequired();
            builder.Property(p => p.ModifiedBy).HasMaxLength(40);

            builder.HasOne(o => o.ItemCategory).WithMany(m => m.Items).HasForeignKey(f => f.CategoryId);

            builder.HasIndex(p => p.CreatedBy);
        }
    }
}
