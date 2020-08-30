using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    public class EmailTest
    {
        private EmailValidator _validator;

        [SetUp]
        public void Setup() =>
            _validator = new EmailValidator();

        [Test]
        public void EmailAddressNotProvided()
        {
            Email email = new Email(string.Empty);
            _validator.CascadeMode = CascadeMode.Stop;
            email.SetValidationResult(this._validator.Validate(email));
            Assert.IsFalse(email.IsValid());
            Assert.AreEqual("Address: Address not provided.", email.GetErrors());
        }

        [Test]
        public void EmailAddresNotValid()
        {
            Email email = new Email("Hello word!", EEmailType.Personal);
            _validator.CascadeMode = CascadeMode.Stop;
            email.SetValidationResult(this._validator.Validate(email));
            Assert.IsFalse(email.IsValid());
            Assert.AreEqual("Address: Invalid email.", email.GetErrors());
        }

        [Test]
        public void EmailTypeNotProvided()
        {
            Email email = new Email("teste@email.com");
            _validator.CascadeMode = CascadeMode.Stop;
            email.SetValidationResult(this._validator.Validate(email));
            Assert.IsFalse(email.IsValid());
            Assert.AreEqual("Type: Email type not provided.", email.GetErrors());
        }

        [Test]
        public void EmailTypeMustBePersonal()
        {
            Email email = new Email("teste@email.com", EEmailType.Personal);
            _validator.CascadeMode = CascadeMode.Stop;
            email.SetValidationResult(this._validator.Validate(email));
            Assert.AreEqual(EEmailType.Personal, email.Type);
        }

        [Test]
        public void EmailTypeMustBeWork()
        {
            Email email = new Email("teste@email.com", EEmailType.Work);
            _validator.CascadeMode = CascadeMode.Stop;
            email.SetValidationResult(this._validator.Validate(email));
            Assert.AreEqual(EEmailType.Work, email.Type);
        }

        [Test]
        public void EmailIsValid()
        {
            Email email = new Email("teste@email.com", EEmailType.Work);
            Assert.IsTrue(email.IsValid());
        }
    }
}
