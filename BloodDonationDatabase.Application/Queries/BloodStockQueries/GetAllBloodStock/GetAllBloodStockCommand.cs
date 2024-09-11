using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.BloodStockQueries.GetAllBloodStock
{
    public class GetAllBloodStockCommand : IRequest<ResultViewModel<List<BloodStockViewModel>>>
    {
    }
}
