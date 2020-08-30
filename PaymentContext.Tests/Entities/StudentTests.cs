using NUnit.Framework;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    public class StudentTests
    {
        private StudentValidator _validation;
        private Document _document;
        private Email _email;
        private Address _address;
        private Name _name;
        [SetUp]

        public void Setup()
        {
            this._validation = new StudentValidator();
        }

        [Test]
        public void StudentInvalid()
        {
            Name name = new Name(string.Empty, string.Empty);
            Document document = new Document(string.Empty);
            Email email = new Email(string.Empty);
            Address address = new Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            Student student = new Student(name, document, email, address);

            student.SetValidationResult(this._validation.Validate(student));
            Assert.False(student.IsValid());
        }
    }
}