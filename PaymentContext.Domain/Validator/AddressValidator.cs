using FluentValidation;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validator
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            ValidateCity();
            ValidateState();
            ValidateStreet();
            ValidateZipCode();
            ValidateCountry();
        }

        void ValidateCountry()
        {
            RuleFor(address => address.Country)
                .NotEmpty().WithMessage("Country not provided.")
                .MinimumLength(3).WithMessage("Country must be at least 3 characters.")
                .MaximumLength(4).WithMessage("Country must have a maximum of 4 characters.");
        }

        void ValidateZipCode()
        {
            RuleFor(address => address.ZipCode)
                .NotEmpty().WithMessage("Zip code not provided.")
                .MinimumLength(8).WithMessage("ZipCode must be at least 8 characters.")
                .MaximumLength(9).WithMessage("ZipCode must have a maximum of 9 characters.");
        }

        void ValidateState()
        {
            RuleFor(address => address.State)
                .NotEmpty().WithMessage("State not provided.")
                .MinimumLength(3).WithMessage("State must be at least 3 characters.");
        }

        void ValidateCity()
        {
            RuleFor(address => address.City)
                .NotEmpty().WithMessage("City not provided.")
                .MinimumLength(3).WithMessage("City must be at least 3 characters.");
        }

        void ValidateStreet()
        {
            RuleFor(address => address.Street)
                .NotEmpty().WithMessage("Street not provided.")
                .MinimumLength(3).WithMessage("Street must be at least 3 characters.");
        }
    }
}
