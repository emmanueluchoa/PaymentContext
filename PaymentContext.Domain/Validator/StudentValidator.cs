using FluentValidation;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Validator
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            ValidateName();
            ValidateEmail();
            ValidateDocument();
            ValidateAddress();
        }

        void ValidateName()
        {
            RuleFor(student => student.Name)
                .NotNull().WithMessage("Name not provided.")
                .SetValidator(new NameValidator());
        }
        void ValidateEmail()
        {
            RuleFor(student => student.Email)
                .NotNull().WithMessage("Email not provided.")
                .SetValidator(new EmailValidator());
        }
        void ValidateDocument()
        {
            RuleFor(student => student.Document)
                .NotNull().WithMessage("Email not provided.")
                .SetValidator(new DocumentValidator());
        }
        void ValidateAddress()
        {
            RuleFor(student => student.Address)
                .NotNull().WithMessage("Email not provided.")
                .SetValidator(new AddressValidator());
        }
    }
}
