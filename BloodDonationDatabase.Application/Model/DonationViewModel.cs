using BloodDonationDatabase.Core.Entities;

namespace BloodDonationDatabase.Application.Model
{
    public class DonationViewModel
    {
        public DonationViewModel(DateTime donationAt, double quantityML, int donorId)
        {
            DonationAt = donationAt;
            QuantityML = quantityML;
            DonorId = donorId;
        }

        public DateTime DonationAt { get; private set; }
        public double QuantityML { get; private set; }
        public int DonorId { get; private set; }

        public static DonationViewModel FromEntity(Donation donation)
            => new DonationViewModel(donation.DonationAt,donation.QuantityML,donation.DonorId);

    }
}
