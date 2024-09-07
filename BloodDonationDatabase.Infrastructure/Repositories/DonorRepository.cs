using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Repository;
using BloodDonationDatabase.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationDatabase.Infrastructure.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodDonationDbContext _dbContext;

        public DonorRepository(BloodDonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Donor?>> GetAll()
        {
            return await _dbContext.Donors
                .Where(d => !d.IsDeleted)
                .ToListAsync();
        }

        public async Task<Donor?> GetById(int id)
        {
            return await _dbContext.Donors
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Insert(Donor donor)
        {
            await _dbContext.Donors.AddAsync(donor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Donor donor)
        {
            _dbContext.Donors.Update(donor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
