using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(DateTime paidDate, DateTime expireDate, decimal total,
         decimal totalPaid, Address address, string payer, Document document, Email email,
         string boletoNumber, string barCode)
         : base(paidDate, expireDate, total, totalPaid, address, payer, document)
        {
            this.Email = email;
            this.BarCode = barCode;
            this.BoletoNumber = boletoNumber;
        }

        public Email Email { get; private set; }
        public string BoletoNumber { get; private set; }
        public string BarCode { get; private set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
