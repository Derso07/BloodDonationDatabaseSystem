using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Enum;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.BloodStockQueries.GetBloodStockByType
{
    public class GetBloodStockByTypeQuery : IRequest<ResultViewModel<BloodStockViewModel>>
    {
        public GetBloodStockByTypeQuery(BloodType? bloodType, RhFactor? rhFactor)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public BloodType? BloodType { get; set; }
        public RhFactor? RhFactor { get; set; }
    }
}
