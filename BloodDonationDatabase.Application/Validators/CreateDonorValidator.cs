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

            RuleFor(d => d.BornAt)
                .NotEmpty();

            RuleFor(d => d.Gender)
                .IsInEnum()
                .NotEmpty();

            RuleFor(d => d.Weight)
                .Must(w => w >= 50)
                .NotEmpty()
                .WithMessage("O peso deve ser maior que 50 Kg");

            RuleFor(d => d.BloodType)
                .IsInEnum()
                .NotEmpty();

            RuleFor(d => d.RhFactor)
                .IsInEnum()
                .NotEmpty();

            RuleFor(d => d.ZipCode)
                .NotEmpty();
        }
    }
}
