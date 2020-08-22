using NUnit.Framework;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    public class StudentTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void StudentInvalid()
        {
            Name name = new Name(string.Empty, string.Empty);
            Document document = new Document(string.Empty);
            Email email = new Email(string.Empty);
            Address address = new Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            Student student = new Student(name, document, email, address);

            Assert.False(student.IsValid());
        }
    }
}