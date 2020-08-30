using FluentValidation;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Validator
{
    public class BoletoPaymentValidator : AbstractValidator<BoletoPayment>
    {
        public BoletoPaymentValidator()
        {
            ValidateEmail();
            ValidateBarCode();
            ValidateBoletoNumeber();
            Include(new PaymentValidator());
        }

        private void ValidateBarCode()
        {
            RuleFor(boleto => boleto.BarCode)
                .NotEmpty().WithMessage("Barcode not provided.");
        }

        private void ValidateBoletoNumeber()
        {
            RuleFor(boleto => boleto.BoletoNumber)
                .NotEmpty().WithMessage("Boleto number not provided.");
        }

        private void ValidateEmail()
        {
            RuleFor(boleto => boleto.Email)
                .NotEmpty().WithMessage("Email not provided.")
                .SetValidator(new EmailValidator());
        }
    }
}
