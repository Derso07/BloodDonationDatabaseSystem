using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Enum;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.BloodStockCommand.UpdateBloodStock
{
    public class UpdateBloodStockCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public double QuantityML { get; set; }
    }
}
