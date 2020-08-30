using FluentValidation;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity<Student>
    {
        private IList<Subscription> _subscriptions;
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get => this._subscriptions.ToArray(); }

        public Student(Name name, Document document, Email email, Address address) : base()
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Address = address;

            if (this._subscriptions == null)
                this._subscriptions = new List<Subscription>();
        }
        public void AddSubscription(Subscription subscription)
        {
            foreach (var currentSubscription in this._subscriptions)
                currentSubscription.Activate(false);

            this._subscriptions.Add(subscription);
        }
    }
}
