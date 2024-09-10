using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonationsQueries.GetAllDonation
{
    public class GetAllDonationCommand : IRequest<ResultViewModel<List<DonationViewModel>>>
    {
    }
}
