using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;

namespace BloodDonationDatabase.Core.Repositories
{
    public interface IBloodStockRespository
    {
        Task Insert(BloodStock bloodStock);
        Task UpdateByType(BloodType bloodType, RhFactor rhFactor, double quantityML);
        Task Update(BloodStock bloodStock);
        Task<BloodStock?> GetById(int id);
        Task<List<BloodStock?>> GetAll();
    }
}
