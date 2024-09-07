using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdCommand : IRequest<ResultViewModel<DonorViewModel>>
    {
        public GetDonorByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
