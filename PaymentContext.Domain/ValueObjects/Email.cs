using FluentValidation;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public EEmailType Type { get; private set; } = EEmailType.NotProvided;
        public string Address { get; private set; }

        public Email(string address, EEmailType type = EEmailType.NotProvided)
        {
            Type = type;
            Address = address;
        }
        public override void Validate()
        {
            ValidateAddress();
            ValidateEmailType();
        }
        private void ValidateAddress()
        {
            RuleFor(email => email.Address)
                .NotEmpty()
                .WithMessage("Email not provided.")
                .EmailAddress()
                .WithMessage("Invalid email.");
        }
        private void ValidateEmailType()
        {
            RuleFor(email => email.Type)
                .NotNull()
                .WithMessage("Email type not provided.")
                .NotEqual(EEmailType.NotProvided)
                .WithMessage("Email type not provided.");
        }
    }
}
