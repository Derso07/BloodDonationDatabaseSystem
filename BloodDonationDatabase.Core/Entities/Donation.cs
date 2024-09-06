namespace BloodDonationDatabase.Core.Entities
{
    public class Donation : BaseEntity
    {
        public Donation(DateTime donationAt, double quantityML, int donorId)
        {
            DonationAt = donationAt;
            QuantityML = quantityML;
            DonorId = donorId;
        }

        public DateTime DonationAt { get; private set; }
        public double QuantityML { get; private set; }
        public int DonorId { get; private set; }
        public Donor Donor { get; private set; }
    }
}
