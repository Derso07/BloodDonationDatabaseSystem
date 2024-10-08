using BloodDonationDatabase.Application.Commands.DonorCommand.InsertDonor;
using FluentValidation;

namespace BloodDonationDatabase.Application.Validators
{
    public class CreateDonorValidator : AbstractValidator<InsertDonorAdressCommand>
    {
        public CreateDonorValidator()
        {
            RuleFor(d => d.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(d => d.FullName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
