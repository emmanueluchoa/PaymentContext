using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests.Entities
{
    public class CreditCardPaymentTests
    {
        private CreditCardPaymentValidator _validator;
        private Address _address;
        private Document _document;

        [SetUp]
        public void SetUp()
        {
            this._validator = new CreditCardPaymentValidator();
            this._document = new Document("33237658006", EDocumentType.CPF);
            this._address = new Address("Rua sem nome", "12345", "12345678", "Cidade Teste", "PER", "BRA", "52020090");
        }

        [Test]
        public void CreditCardNumberNotProvided()
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment(
                DateTime.Now.AddSeconds(-1),
                DateTime.Now,
                decimal.MaxValue,
                decimal.MaxValue,
                this._address,
                "Alguém qualquer",
                this._document,
                Guid.NewGuid().ToString(),
                string.Empty,
                Guid.NewGuid().ToString());

            this._validator.CascadeMode = CascadeMode.Stop;
            creditCardPayment.SetValidationResult(this._validator.Validate(creditCardPayment));

            Assert.IsFalse(creditCardPayment.IsValid());
            Assert.AreEqual("CardNumber: Card number not provided.", creditCardPayment.GetValidationErrors());
        }

        [Test]
        public void CreditCardHolderNameNotProvided()
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment(
                DateTime.Now.AddSeconds(-1),
                DateTime.Now,
                decimal.MaxValue,
                decimal.MaxValue,
                this._address,
                "Alguém qualquer",
                this._document,
                string.Empty,
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString());

            this._validator.CascadeMode = CascadeMode.Stop;
            creditCardPayment.SetValidationResult(this._validator.Validate(creditCardPayment));

            Assert.IsFalse(creditCardPayment.IsValid());
            Assert.AreEqual("CardHolderName: Holder name not provided.", creditCardPayment.GetValidationErrors());
        }

        [Test]
        public void CreditCardLastTransactionNumberNotProvided()
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment(
                DateTime.Now.AddSeconds(-1),
                DateTime.Now,
                decimal.MaxValue,
                decimal.MaxValue,
                this._address,
                "Alguém qualquer",
                this._document,
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                string.Empty);

            this._validator.CascadeMode = CascadeMode.Stop;
            creditCardPayment.SetValidationResult(this._validator.Validate(creditCardPayment));

            Assert.IsFalse(creditCardPayment.IsValid());
            Assert.AreEqual("LastTransactionNumber: Transaction number not provided.", creditCardPayment.GetValidationErrors());
        }
    }
}
