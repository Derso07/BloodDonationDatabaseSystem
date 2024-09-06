using BloodDonationDatabase.Core.Entities;

namespace BloodDonationDatabase.Core.Repository
{
    public interface IDonorRepository
    {
        Task Insert(Donor donor);
    }
}
