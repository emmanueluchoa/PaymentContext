using FluentValidation;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validator
{
    public class NameValidator : AbstractValidator<Name>
    {
        public NameValidator()
        {
            ValidateFirstName();
            ValidateLastName();
        }

        private void ValidateFirstName()
        {
            RuleFor(name => name.FirstName)
                .NotEmpty()
                .WithMessage("First name not provided.")
                .MaximumLength(140)
                .WithMessage("First name max length 140 characters.")
                .MinimumLength(3)
                .WithMessage("First name need at last 3 characters.");
        }

        private void ValidateLastName()
        {
            RuleFor(name => name.LastName)
                .NotEmpty()
                .WithMessage("Last name not provided.")
                .MaximumLength(140)
                .WithMessage("Last name max length 140 character");
        }
    }
}
