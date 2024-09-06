using BloodDonationDatabase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationDatabase.Infrastructure.Configuration
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.ToTable("donors");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(d => d.BornAt)
               .IsRequired()
               .HasColumnType("date");

            builder.Property(d => d.Gender)
               .IsRequired();

            builder.Property(d => d.Weight)
               .IsRequired()
               .HasColumnType("double");

            builder.Property(d => d.BloodType)
               .IsRequired();

            builder.Property(d => d.RhFactor)
               .IsRequired();

            builder.HasOne(d => d.Adress)
                .WithOne(a => a.Donor)
                .HasForeignKey<Donor>(d => d.AdressId);
        }
    }
}
