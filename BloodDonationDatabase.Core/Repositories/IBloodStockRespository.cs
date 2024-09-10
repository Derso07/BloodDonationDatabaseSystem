using BloodDonationDatabase.Core.Entities;

namespace BloodDonationDatabase.Core.Repositories
{
    public interface IBloodStockRespository
    {
        Task Insert(BloodStock bloodStock);
        Task Update(BloodStock bloodStock);
        Task<BloodStock?> GetById(int id);
        Task<List<BloodStock?>> GetAll();
    }
}
