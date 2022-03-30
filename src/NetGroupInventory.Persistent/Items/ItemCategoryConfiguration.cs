using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Persistent.Items
{
    internal class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.ToTable("ItemCategory");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Category).HasMaxLength(200).IsRequired();

            builder.HasData(new ItemCategory[]
            {
                new()
                {
                    Id = 1,
                    Category = "Category 1"
                },
                new()
                {
                    Id = 2,
                    Category = "Category 2"
                },
                new()
                {
                    Id = 3,
                    Category = "Category 3"
                },
                 new()
                {
                    Id = 4,
                    Category = "Category 4"
                }
            });
        }
    }
}
