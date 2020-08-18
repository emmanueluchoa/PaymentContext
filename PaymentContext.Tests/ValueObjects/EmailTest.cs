using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    public class EmailTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void EmailAddressNotProvided()
        {
            Email email = new Email(string.Empty);
            email.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(email.IsValid());
            Assert.AreEqual("Address: Address not provided.", email.GetEntityErrors());
        }

        [Test]
        public void EmailAddresNotValid()
        {
            Email email = new Email("Hello word!", EEmailType.Personal);
            email.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(email.IsValid());
            Assert.AreEqual("Address: Invalid email.", email.GetEntityErrors());
        }

        [Test]
        public void EmailTypeNotProvided()
        {
            Email email = new Email("teste@email.com");
            email.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(email.IsValid());
            Assert.AreEqual("Type: Email type not provided.", email.GetEntityErrors());
        }

        [Test]
        public void EmailTypeMustBePersonal()
        {
            Email email = new Email("teste@email.com", EEmailType.Personal);
            email.CascadeMode = CascadeMode.Stop;
            Assert.AreEqual(EEmailType.Personal, email.Type);
        }

        [Test]
        public void EmailTypeMustBeWork()
        {
            Email email = new Email("teste@email.com", EEmailType.Work);
            email.CascadeMode = CascadeMode.Stop;
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
