using FluentValidation;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Validator
{
    public class PayPalPaymentValidator : AbstractValidator<PayPalPayment>
    {
        public PayPalPaymentValidator()
        {
            Include(new PaymentValidator());
            ValidateEmail();
            ValidateTransactionCode();
        }

        private void ValidateEmail()
        {
            RuleFor(teste => teste.Email)
                .NotEmpty().WithMessage("Email not provided.");
        }

        private void ValidateTransactionCode()
        {
            RuleFor(teste => teste.TransactionCode)
                .NotEmpty().WithMessage("Transaction code not provided.");
        }
    }
}
