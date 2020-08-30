using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(DateTime paidDate, DateTime expireDate, decimal total,
        decimal totalPaid, Address address, string payer, Document document, Email email,
        string transactionCode) : base(paidDate, expireDate, total, totalPaid, address,
         payer, document)
        {
            this.Email = email;
            this.TransactionCode = transactionCode;
        }

        public Email Email { get; private set; }
        public string TransactionCode { get; private set; }
    }
}
