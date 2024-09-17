using BloodDonationDatabase.Core.Entities;

namespace BloodDonationDatabase.Core.Repositories
{
    public interface ICepRepository
    {
        Task<Adress?> CheckAddress(string cep);
    }
}
