using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.DeleteDonation
{
    public class DeleteDonationCommand : IRequest<ResultViewModel>
    {
        public DeleteDonationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
