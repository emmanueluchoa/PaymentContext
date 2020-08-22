using FluentValidation;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Validator
{
    public class PayPalPaymentValidator : AbstractValidator<PayPalPayment>
    {
        public PayPalPaymentValidator()
        {
            this.Validate();
        }

        public void Validate()
        {
            ValidateEmail();
        }

        private void ValidateEmail()
        {
            RuleFor(teste => teste.TransactionCode)
                .NotEmpty().WithMessage("Transaction code not provided.");
        }
    }
}
