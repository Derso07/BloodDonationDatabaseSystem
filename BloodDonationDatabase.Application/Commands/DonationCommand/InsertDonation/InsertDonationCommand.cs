using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Entities;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.InsertDonation
{
    public class InsertDonationCommand : IRequest<ResultViewModel<int>>
    {
        public DateTime DonationAt { get; set; }
        public double QuantityML { get; set; }
        public int DonorId { get; set; }

        public Donation ToEntity()
            => new(DonationAt, QuantityML, DonorId);
    }
}
