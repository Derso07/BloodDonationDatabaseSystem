using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.BloodStockQueries.GetBloodStockById
{
    public class GetBloodStockByIdCommand : IRequest<ResultViewModel<BloodStockViewModel>>
    {
        public GetBloodStockByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
