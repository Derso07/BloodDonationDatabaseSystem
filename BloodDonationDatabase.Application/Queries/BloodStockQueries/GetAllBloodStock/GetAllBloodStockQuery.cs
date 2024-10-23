using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.BloodStockQueries.GetAllBloodStock
{
    public class GetAllBloodStockQuery : IRequest<ResultViewModel<List<BloodStockViewModel>>>
    {
    }
}
