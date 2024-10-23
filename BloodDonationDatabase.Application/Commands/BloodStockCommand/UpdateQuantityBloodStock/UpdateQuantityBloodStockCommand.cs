using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.BloodStockCommand.UpdateQuantityBloodStock
{
    public class UpdateQuantityBloodStockCommand : IRequest<ResultViewModel>
    {
        public UpdateQuantityBloodStockCommand(int id, double removeQuantity)
        {
            Id = id;
            RemoveQuantity = removeQuantity;
        }

        public int Id { get; set; }
        public double RemoveQuantity { get; set; }
    }
}
