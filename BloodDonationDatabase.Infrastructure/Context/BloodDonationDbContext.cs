using BloodDonationDatabase.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationDatabase.Infrastructure.Context
{
    public class BloodDonationDbContext : DbContext
    {
        public BloodDonationDbContext(DbContextOptions<BloodDonationDbContext> options)
            : base(options) 
        {
        }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}
