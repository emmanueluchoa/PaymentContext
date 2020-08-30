using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    public class NameTest
    {
        private NameValidator validator;

        [SetUp]
        public void Setup() =>
            validator = new NameValidator();

        [Test]
        public void FirstNameNotProvided()
        {
            Name name = new Name("", "Cavalcanti");
            validator.CascadeMode = CascadeMode.Stop;
            name.SetValidationResult(validator.Validate(name));
            Assert.False(name.IsValid());
            Assert.AreEqual("FirstName: First name not provided.", name.GetErrors());
        }

        [Test]
        public void LastNameNotProvided()
        {
            Name name = new Name("Emmanuel", "");
            validator.CascadeMode = CascadeMode.Stop;
            name.SetValidationResult(validator.Validate(name));
            Assert.False(name.IsValid());
            Assert.AreEqual("LastName: Last name not provided.", name.GetErrors());
        }

        [Test]
        public void NameIsValid()
        {
            Name name = new Name("Emmanuel", "Cavalcanti");
            name.SetValidationResult(validator.Validate(name));
            Assert.True(name.IsValid(), name.GetErrors());
        }
    }
}