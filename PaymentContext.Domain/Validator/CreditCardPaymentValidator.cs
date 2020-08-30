using FluentValidation;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Validator
{
    public class CreditCardPaymentValidator : AbstractValidator<CreditCardPayment>
    {
        public CreditCardPaymentValidator()
        {
            ValidateCardNumber();
            ValidateCardHolderName();
            ValidateLastTransactionNumber();
            Include(new PaymentValidator());
        }

        private void ValidateCardHolderName()
        {
            RuleFor(creditCard => creditCard.CardHolderName)
                .NotEmpty().WithMessage("Holder name not provided.");
        }

        private void ValidateCardNumber()
        {
            RuleFor(creditCard => creditCard.CardNumber)
                .NotEmpty().WithMessage("Card number not provided.");
        }

        private void ValidateLastTransactionNumber()
        {
            RuleFor(creditCard => creditCard.LastTransactionNumber)
                .NotEmpty().WithMessage("Transaction number not provided.");
        }
    }
}
