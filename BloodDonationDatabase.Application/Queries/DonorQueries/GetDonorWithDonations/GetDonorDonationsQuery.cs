using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonorQueries.GetDonorWithDonations
{
    public class GetDonorDonationsQuery : IRequest<ResultViewModel<DonorDonationsViewModel>>
    {
        public GetDonorDonationsQuery(int donorId)
        {
            DonorId = donorId;
        }

        public int DonorId { get; set; }
    }
}