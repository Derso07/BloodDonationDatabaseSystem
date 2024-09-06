using BloodDonationDatabase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationDatabase.Infrastructure.Configuration
{
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.ToTable("donations");

            builder.HasKey(x => x.Id);

            builder.Property(d => d.DonationAt)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(d => d.QuantityML)
                .IsRequired()
                .HasColumnType("double");

            builder.HasOne(d => d.Donor)
                .WithMany(d => d.Donations)
                .HasForeignKey(d => d.DonorId);
        }
    }
}
