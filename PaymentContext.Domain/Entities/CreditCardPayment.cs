using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            Address address,
            string payer,
            Document document) : base(paidDate,
                expireDate,
                total,
                totalPaid,
                address,
                payer,
                document)
        { }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
