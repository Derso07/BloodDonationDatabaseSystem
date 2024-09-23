using BloodDonationDatabase.Core.Enum;

namespace BloodDonationDatabase.Core.Entities
{
    public class Donor : BaseEntity
    {
        public Donor(string fullName, string email, DateTime bornAt, Gender gender, double weight, BloodType bloodType, RhFactor rhFactor, int adressId)
            : base()
        {
            FullName = fullName;
            Email = email;
            BornAt = bornAt;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            AdressId = adressId;

            Donations = [];
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BornAt { get; private set; }
        public Gender Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactor RhFactor { get; private set; }
        public int AdressId { get; private set; }
        public Adress Adress { get;  set; }
        public List<Donation> Donations { get; set; }

        public void Update(string fullName, string email, Gender gender, double weight, BloodType bloodType, RhFactor rhFactor)
        {
            FullName = fullName;
            Email= email;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public bool CheckWeight()
        {
            if (Weight < 50)
            {
                return false;
            }
            return true;
        }
    }
}