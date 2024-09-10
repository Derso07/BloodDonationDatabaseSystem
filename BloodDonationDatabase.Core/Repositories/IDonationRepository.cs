using BloodDonationDatabase.Core.Entities;

namespace BloodDonationDatabase.Core.Repositories
{
    public interface IDonationRepository
    {
        Task Insert(Donation donation);
        Task Update(Donation donation);
        Task<Donation?> GetById(int id);
        Task<List<Donation?>> GetAll();
    }
}
