using FluentValidation;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject<Name>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override void Validate()
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
