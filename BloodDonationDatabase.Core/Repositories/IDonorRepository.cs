using BloodDonationDatabase.Core.Entities;

namespace BloodDonationDatabase.Core.Repository
{
    public interface IDonorRepository
    {
        Task Insert(Donor donor);
        Task Update(Donor donor);
        Task<Donor?> GetById(int id);
        Task<List<Donor?>> GetAll();
        Task<Donor?> GetByIdWithDonations(int donorId);
    }
}