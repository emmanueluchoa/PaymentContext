using NUnit.Framework;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    public class NameTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void FirstNameNotProvided()
        {
            Name name = new Name("", "Cavalcanti");
            name.Validate();

            Assert.False(name.IsValid());
        }

        [Test]
        public void LastNameNotProvided()
        {
            Name name = new Name("Emmanuel", "");
            name.Validate();

            Assert.False(name.IsValid());
        }

        [Test]
        public void NameIsValid()
        {
            Name name = new Name("Emmanuel", "Cavalcanti");
            name.Validate();

            Assert.True(name.IsValid(), name.GetEntityErrors());
        }

        [Test]
        public void NameNotProvided()
        {
            Name name = new Name("", "");
            name.Validate();

            Assert.False(name.IsValid());
        }
    }
}