using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.BloodStockCommand.DeleteBloodStock
{
    public class DeleteBloodStockCommand : IRequest<ResultViewModel>
    {
        public DeleteBloodStockCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
