using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.UpdateDonation
{
    public class UpdateDonationCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public DateTime DonationAt { get; set; }
        public double QuantityML { get; set; }
        public int DonorId { get; set; }
    }
}
