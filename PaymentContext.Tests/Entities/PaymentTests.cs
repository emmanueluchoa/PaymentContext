using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests.Entities
{
    public class PaymentTests
    {
        private Document _document;
        private Address _address;
        [SetUp]
        public void Setup()
        {
            this._document = new Document("33237658006", EDocumentType.CPF);
            this._address = new Address("Rua sem nome", "12345", "12345678", "Cidade Teste", "PE", "BRA", "52020090");
        }

        [Test]
        public void PaymentIsInvalid()
        {
            PaymentValidator payment = new PaymentValidator(DateTime.MinValue, DateTime.MinValue, 0, 0, null, string.Empty, null);
            Assert.IsFalse(payment.IsValid());
        }

        [Test]
        public void PaidDateNotProvided()
        {
            PaymentValidator payment = new PaymentValidator(DateTime.MinValue, DateTime.Now.AddDays(5), 10, 10, this._address, "Alguém qualquer", this._document);
            payment.CascadeMode = CascadeMode.Stop;
            payment.IsValid();
            Assert.AreEqual("PaidDate : Paid date not provided.", payment.GetEntityErrors());
        }

        [Test]
        public void FuturePaidDateIsInvalid()
        {
            PaymentValidator payment = new PaymentValidator(DateTime.Now.AddDays(10), DateTime.Now.AddDays(5), 10, 10, this._address, "Alguém qualquer", this._document);
            payment.IsValid();
            Assert.AreEqual("PaidDate : Future paid date is invalid.", payment.GetEntityErrors());
        }
    }
}
