using BloodDonationDatabase.Application.Model;
using FluentValidation;

namespace BloodDonationDatabase.Application.Validators
{
    public class AdressValidator : AbstractValidator<AdressViewModel>
    {
        public AdressValidator() 
        {
            RuleFor(a => a.Street)
                .NotEmpty();

            RuleFor(a => a.City)
                .NotEmpty();

            RuleFor(a => a.State)
                .NotEmpty();

            RuleFor(a => a.ZipCode)
                .NotEmpty();
        }
    }
}
