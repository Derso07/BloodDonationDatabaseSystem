using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Repositories;
using BloodDonationDatabase.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationDatabase.Infrastructure.Repositories
{
    public class BloodStockRepository : IBloodStockRespository
    {
        public BloodStockRepository(BloodDonationDbContext context)
        {
            _context = context;
        }
        private readonly BloodDonationDbContext _context;

        public async Task<List<BloodStock?>> GetAll()
        {
            return await _context.BloodStocks
                .Where(b => !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<BloodStock?> GetById(int id)
        {
            return await _context.BloodStocks
                .Where (b => !b.IsDeleted)
                .FirstOrDefaultAsync(b=> b.Id == id);
        }

        public async Task Insert(BloodStock bloodStock)
        {
            await _context.BloodStocks
                .AddAsync(bloodStock);

            await _context.SaveChangesAsync(); 
        }

        public async Task Update(BloodStock bloodStock)
        {
            _context.Update(bloodStock);
            await _context.SaveChangesAsync();
        }
    }
}
