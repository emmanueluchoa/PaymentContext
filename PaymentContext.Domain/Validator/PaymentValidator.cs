using FluentValidation;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.Validator
{
    public class PaymentValidator : Payment
    {
        public PaymentValidator(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Address address, string payer, Document document)
            : base(paidDate, expireDate, total, totalPaid, address, payer, document) { }

        public override void Validate()
        {
            ValidatePayer();
            ValidateTotal();
            ValidatePaidDate();
            ValidateDocument();
            ValidateTotalPaid();
            ValidateExpireDate();
        }

        private void ValidatePayer()
        {
            RuleFor(payment => payment.Payer)
                .NotEmpty().WithMessage("Payer not provided.");
        }

        private void ValidateTotal()
        {
            RuleFor(payment => payment.Total)
                .NotNull().WithMessage("Total not provided.")
                .GreaterThan(-1).WithMessage("Total cant be negative.");
        }

        private void ValidateTotalPaid()
        {
            RuleFor(payment => payment.TotalPaid)
                .NotNull().WithMessage("Total not provided.")
                .GreaterThan(-1).WithMessage("Total cant be negative.");
        }

        private void ValidatePaidDate()
        {
            RuleFor(payment => payment.PaidDate)
                .NotEmpty().WithMessage("Paid date not provided.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Future paid date is invalid.");
        }

        private void ValidateExpireDate()
        {
            RuleFor(payment => payment.ExpireDate)
                .NotEmpty().WithMessage("Expire date not provided");
        }

        private void ValidateDocument()
        {
            RuleFor(payment => payment.Document)
                .NotEmpty().WithMessage("Document not provided.")
                .SetValidator(new Document(string.Empty));
        }
    }
}
