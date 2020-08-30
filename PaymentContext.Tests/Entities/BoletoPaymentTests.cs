using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests.Entities
{
    public class BoletoPaymentTests
    {
        private Email _email;
        private Address _address;
        private Document _document;
        private BoletoPaymentValidator _validator;

        [SetUp]
        public void SetUp()
        {
            this._validator = new BoletoPaymentValidator();
            this._email = new Email("teste@email.com", EEmailType.Personal);
            this._document = new Document("33237658006", EDocumentType.CPF);
            this._address = new Address("Rua sem nome", "12345", "12345678", "Cidade Teste", "PER", "BRA", "52020090");
        }

        [Test]
        public void BoletoBarCodeNotProvided()
        {
            BoletoPayment boletoPayment = new BoletoPayment(DateTime.Now.AddSeconds(-1), DateTime.Now, decimal.MaxValue, decimal.MaxValue, this._address, "Alguém qualquer", this._document, this._email, Guid.NewGuid().ToString(), string.Empty);
            this._validator.CascadeMode = CascadeMode.Stop;
            boletoPayment.SetValidationResult(this._validator.Validate(boletoPayment));
            Assert.IsFalse(boletoPayment.IsValid());

            Assert.AreEqual("BarCode: Barcode not provided.", boletoPayment.GetValidationErrors());
        }

        [Test]
        public void BoletoNumberNotProvided()
        {
            BoletoPayment boletoPayment = new BoletoPayment(DateTime.Now.AddSeconds(-1), DateTime.Now, decimal.MaxValue, decimal.MaxValue, this._address, "Alguém qualquer", this._document, this._email, string.Empty, Guid.NewGuid().ToString());
            this._validator.CascadeMode = CascadeMode.Stop;
            boletoPayment.SetValidationResult(this._validator.Validate(boletoPayment));
            Assert.IsFalse(boletoPayment.IsValid());

            Assert.AreEqual("BoletoNumber: Boleto number not provided.", boletoPayment.GetValidationErrors());
        }
    }
}
