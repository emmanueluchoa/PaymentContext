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
            Document = document;
            Address = address;

            if (this._subscriptions == null)
                this._subscriptions = new List<Subscription>();
        }
        public void AddSubscription(Subscription subscription)
        {
            foreach (var currentSubscription in this._subscriptions)
                currentSubscription.Activate(false);

            this._subscriptions.Add(subscription);
        }
        public override void Validate()
        {
            ValidateName();
            ValidateEmail();
            ValidateDocument();
            ValidateAddress();
        }
        void ValidateName()
        {
            RuleFor(student => student.Name)
                .NotNull().WithMessage("Name not provided.")
                .SetValidator(new Name(string.Empty, string.Empty));
        }
        void ValidateEmail()
        {
            RuleFor(student => student.Email)
                .NotNull().WithMessage("Email not provided.")
                .SetValidator(new Email(string.Empty));
        }
        void ValidateDocument()
        {
            RuleFor(student => student.Document)
                .NotNull().WithMessage("Email not provided.")
                .SetValidator(new Document(string.Empty));
        }
        void ValidateAddress()
        {
            RuleFor(student => student.Address)
                .NotNull().WithMessage("Email not provided.")
                .SetValidator(new Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
        }
    }
}
