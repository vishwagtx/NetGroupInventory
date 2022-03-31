using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Persistent.Storage
{
    internal class StorageLevelConfiguration : IEntityTypeConfiguration<StorageLevel>
    {
        public void Configure(EntityTypeBuilder<StorageLevel> builder)
        {
            builder.ToTable("StorageLevel");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Level).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(5000);

            builder.Property(p => p.CreatedBy).HasMaxLength(40).IsRequired();
            builder.Property(p => p.ModifiedBy).HasMaxLength(40);

            builder.HasIndex(p => p.CreatedBy);
        }
    }
}
