using BloodDonationDatabase.Application.Model;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonorCommand.InsertDonor
{
    public class InsertDonorCommand : IRequest<ResultModel>
    {
        public InsertDonorCommand(string fullName, string email, DateTime bornAt, int gender, double weight, int bloodType, int rhFactor, int adressId)
        {
            FullName = fullName;
            Email = email;
            BornAt = bornAt;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            AdressId = adressId;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BornAt { get; set; }
        public int Gender { get; set; }
        public double Weight { get; set; }
        public int BloodType { get; set; }
        public int RhFactor { get; set; }
        public int AdressId { get; set; }

    }
}
