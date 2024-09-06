using BloodDonationDatabase.Core.Enum;

namespace BloodDonationDatabase.Core.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(BloodType bloodType, RhFactor rhFactor, double quantityML)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityML = quantityML;
        }

        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public double QuantityML { get; private set; }

    }
}
