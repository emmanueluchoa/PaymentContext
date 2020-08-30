using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests.Entities
{
    public class PayPalPaymentTests
    {
        private Document _document;
        private Address _address;
        private Email _email;

        [SetUp]
        public void Setup()
        {
            this._email = new Email("teste@email.com", EEmailType.Personal);
            this._document = new Document("33237658006", EDocumentType.CPF);
            this._address = new Address("Rua sem nome", "12345", "12345678", "Cidade Teste", "PER", "BRA", "52020090");
        }

        [Test]
        public void EmailNotProvided()
        {
            PayPalPayment paypalPayment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, this._address, "Payer test", this._document, null, Guid.NewGuid().ToString());
            PayPalPaymentValidator paypalPaymentValidator = new PayPalPaymentValidator();
            paypalPaymentValidator.CascadeMode = CascadeMode.Stop;
            paypalPayment.SetValidationResult(paypalPaymentValidator.Validate(paypalPayment));
            Assert.IsFalse(paypalPayment.IsValid());
            Assert.AreEqual("Email: Email not provided.", paypalPayment.GetValidationErrors());
        }
    }
}
