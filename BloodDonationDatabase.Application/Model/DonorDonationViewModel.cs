using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;

namespace BloodDonationDatabase.Application.Model
{
    public class DonorDonationViewModel
    {
        public DateTime BornAt { get; set; }
        public DateTime DonationAt { get; set; }
        public Gender Gender { get; set; }

        public static DonorDonationViewModel FromEntity(Donor donor, Donation donation)
            => new DonorDonationViewModel { BornAt = donor.BornAt, Gender = donor.Gender, DonationAt = donation.DonationAt };
    }
}