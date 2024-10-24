using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;

namespace BloodDonationDatabase.Core.Repositories
{
    public interface IBloodStockRespository
    {
        Task Insert(BloodStock bloodStock);
        Task UpdateByType(BloodType bloodType, RhFactor rhFactor, double quantityML);
        Task Update(BloodStock bloodStock);
        Task<bool>WithdrawBlood(int id, double quantityRemoved);
        Task<BloodStock?> GetById(int id);
        Task<BloodStock?> GetByType(BloodType? bloodType, RhFactor? rhFactor);
        Task<List<BloodStock?>> GetAll();
    }
}
