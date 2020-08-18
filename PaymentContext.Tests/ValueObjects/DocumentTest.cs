using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void DocumentNumberNotProvided()
        {
            Document document = new Document(string.Empty, EDocumentType.CNPJ);
            document.CascadeMode = CascadeMode.Stop;
            document.IsValid();
            Assert.AreEqual("Number: Document number not provided.", document.GetEntityErrors());
        }

        [Test]
        public void DocumentTypeNotProvided()
        {
            Document document = new Document("19899462080");
            document.IsValid();
            Assert.IsTrue(document.Type == EDocumentType.NotProvided);
            Assert.AreEqual("Type: Document type not provided.", document.GetEntityErrors());
        }

        [Test]
        public void DocumentTypeMustBeCPF()
        {
            Document document = new Document("19899462080", EDocumentType.CPF);
            Assert.IsTrue(document.Type == EDocumentType.CPF);
        }

        [Test]
        public void DocumentNumberTypeCPFMustBeValid()
        {
            Document document = new Document("19899462080", EDocumentType.CPF);
            Assert.IsTrue(document.Type == EDocumentType.CPF);
            Assert.IsTrue(document.IsValid());
        }

        [Test]
        public void DocumentNumberLenghtTypeCPFMustNotBe11Characters()
        {
            Document document = new Document("123", EDocumentType.CPF);
            document.CascadeMode = CascadeMode.Stop;
            Assert.IsTrue(document.Type == EDocumentType.CPF);
            Assert.IsFalse(document.IsValid());
            Assert.AreEqual("Number: CPF must have 11 characters.", document.GetEntityErrors());
        }

        [Test]
        public void DocumentTypeMustByCNPJ()
        {
            Document document = new Document("84131285000190", EDocumentType.CNPJ);
            Assert.IsTrue(document.Type == EDocumentType.CNPJ);
        }

        [Test]
        public void DocumentTypeCNPJMustByValid()
        {
            Document document = new Document("84131285000190", EDocumentType.CNPJ);
            Assert.IsTrue(document.Type == EDocumentType.CNPJ);
            Assert.IsTrue(document.IsValid());
        }
    }
}
