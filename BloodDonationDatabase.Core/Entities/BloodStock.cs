﻿using BloodDonationDatabase.Core.Enum;

namespace BloodDonationDatabase.Core.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(BloodType bloodType, RhFactor rhFactor, double quantityML, double minimumQuantity)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityML = quantityML;
            MinimumQuantity = minimumQuantity;
        }

        public BloodStock(BloodType bloodType, RhFactor rhFactor, double quantityML)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityML = quantityML;
        }

        public BloodType BloodType { get; private set; }
        public RhFactor RhFactor { get; private set; }
        public double QuantityML { get; private set; }
        public double MinimumQuantity { get; private set; }

        public void Update(BloodType bloodType, RhFactor rhFactor, double quantityML)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityML = quantityML;
        }

        public void UpdateQuantityByType(double quantityMl)
        {
            QuantityML += quantityMl;
        }

        public bool RemoveQuantity(double quantityRemoved)
        {
            if (quantityRemoved > QuantityML || quantityRemoved <= 0)
            {
                return false;
            }
            QuantityML -= quantityRemoved;

            return true;
        }

        public bool ReachedTheMinimum()
        {
            return MinimumQuantity > QuantityML;
        }
    }
}
