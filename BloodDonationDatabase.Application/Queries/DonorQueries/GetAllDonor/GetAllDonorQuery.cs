using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonorQueries.GetAllDonor
{
    public class GetAllDonorQuery : IRequest<ResultViewModel<List<DonorViewModel>>>
    {
    }
}
