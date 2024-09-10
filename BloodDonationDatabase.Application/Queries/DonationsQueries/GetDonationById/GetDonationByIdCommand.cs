using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonationsQueries.GetDonationById
{
    public class GetDonationByIdCommand : IRequest<ResultViewModel<DonationViewModel>>
    {
        public GetDonationByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
