using BloodDonationDatabase.Application.Commands.DonationCommand.InsertDonation;
using FluentValidation;

namespace BloodDonationDatabase.Application.Validators
{
    public class CreateDonationValidator : AbstractValidator<InsertDonationCommand>
    {
        public CreateDonationValidator()
        {
            RuleFor(u => u.QuantityML)
                .InclusiveBetween(420, 470)
                .WithMessage("Deve está entre 420 e 470");

            RuleFor(u => u.Donor)
                .SetValidator(new DonorDonationValidator());
        }
    }
}