using BloodDonationDatabase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationDatabase.Infrastructure.Configuration
{
    public class BloodStockConfiguration : IEntityTypeConfiguration<BloodStock>
    {
        public void Configure(EntityTypeBuilder<BloodStock> builder)
        {
            builder.ToTable("bloodstocks");

            builder.HasKey(x => x.Id);

            builder.Property(b => b.BloodType)
               .IsRequired();

            builder.Property(b => b.RhFactor)
               .IsRequired();

            builder.Property(b => b.QuantityML)
               .IsRequired()
               .HasColumnType("double");
        }
    }
}
