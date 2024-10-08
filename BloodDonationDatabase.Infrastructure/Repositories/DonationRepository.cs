using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Repositories;
using BloodDonationDatabase.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationDatabase.Infrastructure.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodDonationDbContext _context;

        public DonationRepository(BloodDonationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Donation?>> GetAll()
        {
            return await _context.Donations
                .Where(d => !d.IsDeleted)
                .ToListAsync();
        }

        public async Task<Donation?> GetByDonorId(int donorId)
        {
            return await _context.Donations
                .Where(d => d.DonorId == donorId &&
                !d.IsDeleted)
                .OrderBy(d => d.DonationAt)
                .FirstOrDefaultAsync();
        }

        public async Task<Donation?> GetById(int id)
        {
            return await _context.Donations
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Insert(Donation donation)
        {
            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Donation donation)
        {
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync();
        }
    }
}
