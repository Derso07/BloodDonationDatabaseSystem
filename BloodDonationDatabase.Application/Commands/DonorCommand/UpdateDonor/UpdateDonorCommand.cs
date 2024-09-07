using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonorCommand.UpdateDonor
{
    public class UpdateDonorCommand : IRequest<ResultViewModel>
    {
        public int IdDonor { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BornAt { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
    }
}
