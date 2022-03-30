using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Persistent.Stoarge
{
    internal class StoargeLevelConfiguration : IEntityTypeConfiguration<StoargeLevel>
    {
        public void Configure(EntityTypeBuilder<StoargeLevel> builder)
        {
            builder.ToTable("StoargeLevel");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Level).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(5000);

            builder.Property(p => p.CreatedBy).HasMaxLength(40).IsRequired();
            builder.Property(p => p.ModifiedBy).HasMaxLength(40);

            builder.HasIndex(p => p.CreatedBy);
        }
    }
}
