using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Entities;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.InsertDonation
{
    public class InsertDonationCommand : IRequest<ResultViewModel<int>>
    {
        public int Id { get; set; }
        public DateTime DonationAt { get; private set; }
        public double QuantityML { get; private set; }
        public int DonorId { get; private set; }

        public Donation ToEntity()
            => new(DonationAt, QuantityML, DonorId);
    }
}
