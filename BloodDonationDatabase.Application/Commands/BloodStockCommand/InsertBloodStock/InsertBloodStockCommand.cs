using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.BloodStockCommand.InsertBloodStock
{
    public class InsertBloodStockCommand : IRequest<ResultViewModel<int>>
    {
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public double QuantityML { get; set; }
        public double MinimumQuantity { get; set; }

        public BloodStock ToEntity()
            => new(BloodType, RhFactor, QuantityML, MinimumQuantity);
    }
}
