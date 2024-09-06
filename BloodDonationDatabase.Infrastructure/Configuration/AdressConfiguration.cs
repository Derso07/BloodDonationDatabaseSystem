using BloodDonationDatabase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationDatabase.Infrastructure.Configuration
{
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("adresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
