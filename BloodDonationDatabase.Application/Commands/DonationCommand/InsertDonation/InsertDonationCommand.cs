using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.InsertDonation
{
    public class InsertDonationCommand : IRequest<ResultViewModel<int>>
    {
        public DateTime DonationAt { get; set; }
        public double QuantityML { get; set; }
        public int DonorId { get; set; }
        [JsonIgnore]
        public DonorDonationViewModel? Donor { get; set; }

        public Donation ToEntity()
            => new(DonationAt, QuantityML, DonorId);
    }
}
