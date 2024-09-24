using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonorCommand.InsertDonor
{
    public class InsertDonorAdressCommand : IRequest<ResultViewModel<int>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BornAt { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public string ZipCode { get; set; }
        public int AdressId { get; set; }
        public Donor ToEntity()
            => new(FullName, Email, BornAt, Gender, Weight, BloodType, RhFactor, AdressId);

    }
}
