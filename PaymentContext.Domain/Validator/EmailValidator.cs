using FluentValidation;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validator
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            ValidateAddress();
            ValidateEmailType();
        }

        private void ValidateAddress()
        {
            RuleFor(email => email.Address)
                .NotEmpty()
                .WithMessage("Address not provided.")
                .EmailAddress()
                .WithMessage("Invalid email.");
        }

        private void ValidateEmailType()
        {
            RuleFor(email => email.Type)
                .NotEqual(EEmailType.NotProvided)
                .WithMessage("Email type not provided.");
        }
    }
}
