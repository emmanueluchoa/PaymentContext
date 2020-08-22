using FluentValidation;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity<Payment>
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total,
        decimal totalPaid, Address address, string payer, Document document) : base()
        {
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Payer = payer;
            Document = document;
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Address Address { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
    }
}
