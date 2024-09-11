using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;

namespace BloodDonationDatabase.Application.Model
{
    public class BloodStockViewModel
    {
        public BloodStockViewModel(BloodType bloodType, RhFactor rhFactor, double quantityML)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityML = quantityML;
        }

        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public double QuantityML { get; private set; }

        public static BloodStockViewModel FromEntity(BloodStock bloodStock)
            => new(bloodStock.BloodType, bloodStock.RhFactor, bloodStock.QuantityML);

    }
}
