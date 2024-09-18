using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdQuery : IRequest<ResultViewModel<DonorViewModel>>
    {
        public GetDonorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
