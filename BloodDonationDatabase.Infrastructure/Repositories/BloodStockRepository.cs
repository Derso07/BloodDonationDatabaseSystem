using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;
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

        public async Task UpdateByType(BloodType bloodType, RhFactor rhFactor, double quantityML)
        {
            var bloodStock = await _context.BloodStocks
                .Where(b => b.BloodType == bloodType)
                .Where(b => b.RhFactor == rhFactor)
                .FirstOrDefaultAsync();

            if (bloodStock is not null)
            {
                bloodStock.UpdateQuantityByType(quantityML);
                await Update(bloodStock);
            }
            else
            {
                var newBloodStock = new BloodStock(bloodType, rhFactor, quantityML);
                await Insert(newBloodStock);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BloodStock?> GetByType(BloodType? bloodType, RhFactor? rhFactor)
        {
            var bloodStock = await _context.BloodStocks
                .Where(b => b.BloodType == bloodType && b.RhFactor == rhFactor)
                .FirstOrDefaultAsync();

            return bloodStock;
        }

        public async Task<bool> WithdrawBlood(int id, double quantityRemoved)
        {
            var bloodStock = await GetById(id);

            var result = bloodStock.RemoveQuantity(quantityRemoved);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}