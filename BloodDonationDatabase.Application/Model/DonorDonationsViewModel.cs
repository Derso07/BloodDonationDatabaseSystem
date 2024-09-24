using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;

namespace BloodDonationDatabase.Application.Model
{
    public class DonorDonationsViewModel
    {
        public DonorDonationsViewModel(string fullName, string email, DateTime bornAt, Gender gender, double weight, BloodType bloodType, RhFactor rhFactor, List<DonationViewModel> donations)
        {
            FullName = fullName;
            Email = email;
            BornAt = bornAt;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Donations = donations;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BornAt { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public List<DonationViewModel> Donations { get; set; }

        public static DonorDonationsViewModel FromEntity(Donor donor)
            => new(donor.FullName, donor.Email, donor.BornAt, donor.Gender, donor.Weight, donor.BloodType, donor.RhFactor, donor.Donations.Select(DonationViewModel.FromEntity).ToList());
    }
}