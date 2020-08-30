using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentTest
    {
        private DocumentValidator _validator;

        [SetUp]
        public void Setup() =>
            this._validator = new DocumentValidator();

        [Test]
        public void DocumentNumberNotProvided()
        {
            Document document = new Document(string.Empty, EDocumentType.CNPJ);
            this._validator.CascadeMode = CascadeMode.Stop;
            document.SetValidationResult(this._validator.Validate(document));
            Assert.IsFalse(document.IsValid());
            Assert.AreEqual("Number: Document number not provided.", document.GetErrors());
        }

        [Test]
        public void DocumentTypeNotProvided()
        {
            Document document = new Document("19899462080");
            this._validator.CascadeMode = CascadeMode.Stop;
            document.SetValidationResult(this._validator.Validate(document));
            Assert.IsFalse(document.IsValid());
            Assert.AreEqual(document.Type, EDocumentType.NotProvided);
            Assert.AreEqual("Type: Document type not provided.", document.GetErrors());
        }

        [Test]
        public void DocumentTypeMustBeCPF()
        {
            Document document = new Document("19899462080", EDocumentType.CPF);
            Assert.AreEqual(EDocumentType.CPF, document.Type);
        }

        [Test]
        public void DocumentNumberTypeCPFMustBeValid()
        {
            Document document = new Document("19899462080", EDocumentType.CPF);
            Assert.AreEqual(document.Type, EDocumentType.CPF);
            this._validator.CascadeMode = CascadeMode.Stop;
            document.SetValidationResult(this._validator.Validate(document));
            Assert.IsTrue(document.IsValid());
        }

        [Test]
        public void DocumentNumberLenghtTypeCPFMustNotBe11Characters()
        {
            Document document = new Document("123", EDocumentType.CPF);
            this._validator.CascadeMode = CascadeMode.Stop;
            document.SetValidationResult(this._validator.Validate(document));
            Assert.AreEqual(document.Type, EDocumentType.CPF);
            Assert.IsFalse(document.IsValid());
            Assert.AreEqual("Number: CPF must have 11 characters.", document.GetErrors());
        }

        [Test]
        public void DocumentTypeMustByCNPJ()
        {
            Document document = new Document("84131285000190", EDocumentType.CNPJ);
            Assert.AreEqual(EDocumentType.CNPJ, document.Type);
        }

        [Test]
        public void DocumentTypeCNPJMustByValid()
        {
            Document document = new Document("84131285000190", EDocumentType.CNPJ);
            this._validator.CascadeMode = CascadeMode.Stop;
            document.SetValidationResult(this._validator.Validate(document));
            Assert.AreEqual(document.Type, EDocumentType.CNPJ);
            Assert.IsTrue(document.IsValid());
        }
    }
}
