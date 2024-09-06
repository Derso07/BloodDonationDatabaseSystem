using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Repository;
using BloodDonationDatabase.Infrastructure.Context;

namespace BloodDonationDatabase.Infrastructure.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonorRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(Donor donor)
        {
            await _dbContext.Donors.AddAsync(donor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
