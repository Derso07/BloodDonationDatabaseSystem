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

        public void Update(DateTime donationAt, double quantityMl, int donorId)
        {
            DonationAt = donationAt;
            QuantityML = quantityMl;
            DonorId = donorId;
        }

        public bool CheckAge()
        {
            var currentDate = DateTime.UtcNow;
            var bornAt = Donor.BornAt;
            var age = currentDate.Year - bornAt.Year;

            if (age > 18) return true;
            else if (age == 18)
            {
                if (bornAt.Month < currentDate.Month)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool WomenDonation()
        {
            DateTime currentDate = DateTime.UtcNow;
            TimeSpan difference = currentDate - DonationAt;

            return difference.TotalDays >= 90;
        }

        public bool MenDonation()
        {
            DateTime currentDate = DateTime.UtcNow;
            TimeSpan difference = currentDate - DonationAt;

            return difference.TotalDays >= 60;
        }

        public bool CheckQuantityMlDonation()
        {
            return QuantityML > 420 && QuantityML < 470;
        }
    }
}