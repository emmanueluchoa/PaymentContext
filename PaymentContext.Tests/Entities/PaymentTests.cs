using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Entities;
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
        private PaymentValidator _validator;

        [SetUp]
        public void Setup()
        {
            this._document = new Document("33237658006", EDocumentType.CPF);
            this._address = new Address("Rua sem nome", "12345", "12345678", "Cidade Teste", "PER", "BRA", "52020090");
            this._validator = new PaymentValidator();
        }

        [Test]
        public void PaymentIsInvalid()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.MinValue, DateTime.MinValue, 0, 0, null, string.Empty, null);
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.IsFalse(payment.IsValid());
        }

        [Test]
        public void PaidDateNotProvided()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.MinValue, DateTime.Now.AddDays(5), 10, 10, this._address, "Alguém qualquer", this._document);
            this._validator.CascadeMode = CascadeMode.Stop;
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.False(payment.IsValid());
            Assert.AreEqual("PaidDate: Paid date not provided.", payment.GetValidationErrors());
        }

        [Test]
        public void FuturePaidDateIsInvalid()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.Now.AddDays(10), DateTime.Now.AddDays(5), 10, 10, this._address, "Alguém qualquer", this._document);
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.IsFalse(payment.IsValid());
            Assert.AreEqual("PaidDate: Future paid date is invalid.", payment.GetValidationErrors());
        }

        [Test]
        public void ExpireDateNotProvided()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.Now.AddSeconds(-1), DateTime.MinValue, 10, 10, this._address, "Alguém qualquer", this._document);
            this._validator.CascadeMode = CascadeMode.Stop;
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.IsFalse(payment.IsValid());
            Assert.AreEqual("ExpireDate: Expire date not provided.", payment.GetValidationErrors());
        }

        [Test]
        public void TotalCantBeNegative()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.Now, DateTime.Now, decimal.MinValue, 10, this._address, "Alguém qualquer", this._document);
            this._validator.CascadeMode = CascadeMode.Stop;
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.IsFalse(payment.IsValid());
            Assert.AreEqual("Total: Total cant be negative.", payment.GetValidationErrors());
        }

        [Test]
        public void TotalPaidCantBeNegative()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.Now.AddSeconds(-1), DateTime.Now, 10, decimal.MinValue, this._address, "Alguém qualquer", this._document);
            this._validator.CascadeMode = CascadeMode.Stop;
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.IsFalse(payment.IsValid());
            Assert.AreEqual("TotalPaid: Total cant be negative.", payment.GetValidationErrors());
        }

        [Test]
        public void PayerNotProvided()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.Now, DateTime.Now, decimal.MaxValue, decimal.MaxValue, this._address, string.Empty, this._document);
            this._validator.CascadeMode = CascadeMode.Stop;
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.IsFalse(payment.IsValid());
            Assert.AreEqual("Payer: Payer not provided.", payment.GetValidationErrors());
        }

        [Test]
        public void AddressNotProvided()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.Now, DateTime.Now, decimal.MaxValue, decimal.MaxValue, null, "Alguém qualquer", this._document);
            this._validator.CascadeMode = CascadeMode.Stop;
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.IsFalse(payment.IsValid());
            Assert.AreEqual("Address: Address not provided.", payment.GetValidationErrors());
        }

        [Test]
        public void DocumentNotProvided()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.Now.AddSeconds(-1), DateTime.Now.AddDays(5), decimal.MaxValue, decimal.MaxValue, this._address, "Alguém qualquer", null);
            this._validator.CascadeMode = CascadeMode.Stop;
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.IsFalse(payment.IsValid());
            Assert.AreEqual("Document: Document not provided.", payment.GetValidationErrors());
        }

        [Test]
        public void PaymentIsValid()
        {
            PaymentTestImplementation payment = new PaymentTestImplementation(DateTime.Now.AddSeconds(-1), DateTime.Now, decimal.MaxValue, decimal.MaxValue, this._address, "Alguém qualquer", this._document);
            payment.SetValidationResult(this._validator.Validate(payment));
            Assert.IsTrue(payment.IsValid());
        }
    }
}
