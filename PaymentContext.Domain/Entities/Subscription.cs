using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity<Subscription>
    {
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUptadeDate = DateTime.Now;
            ExpireDate = expireDate;

            if (this._payments == null)
                this._payments = new List<Payment>();
        }

        private readonly IList<Payment> _payments;  
        public DateTime CreateDate { get; private set; }
        public DateTime LastUptadeDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; } = false;
        public IReadOnlyCollection<Payment> Payments { get => this._payments.ToArray(); }

        public void AddPayment(Payment payment)
        {
            this._payments.Add(payment);
        }

        public void Activate(bool isActive = true)
        {
            this.Active = isActive;
            LastUptadeDate = DateTime.Now;
        }
    }
}
