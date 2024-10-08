using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Enum;
using FluentValidation;

namespace BloodDonationDatabase.Application.Validators
{
    public class DonorDonationValidator : AbstractValidator<DonorDonationViewModel>
    {
        public DonorDonationValidator() 
        {
            RuleFor(u => u.BornAt)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage("Deve ser maior de idade.");

            RuleFor(d => d.DonationAt)
                .Must(WomenDonation)
                .When(d => d.Gender == Gender.Female)
                .WithMessage("Mulheres só podem doar a cada 90 dias.");

            RuleFor(d => d.DonationAt)
                .Must(MenDonation)
                .When(d => d.Gender == Gender.Male)
                .WithMessage("Homens só podem doar a cada 60 dias.");
        }

        public bool WomenDonation(DateTime donationAt)
        {
            DateTime currentDate = DateTime.UtcNow;
            TimeSpan difference = currentDate - donationAt;

            return difference.TotalDays >= 90;
        }

        public bool MenDonation(DateTime donationAt)
        {
            DateTime currentDate = DateTime.UtcNow;
            TimeSpan difference = currentDate - donationAt;

            return difference.TotalDays >= 60;
        }
    }
}
