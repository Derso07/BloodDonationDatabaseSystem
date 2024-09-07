using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonorCommand.DeleteDonor
{
    public class DeleteDonorCommand : IRequest<ResultViewModel>
    {
        public DeleteDonorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
