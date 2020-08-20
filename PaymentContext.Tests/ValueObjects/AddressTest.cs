using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    public class AddressTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void StreetNotProvided()
        {
            Address address = new Address(string.Empty, "abc", "abc", "abc", "abc", "abc", "abcdefgh");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Street: Street not provided.", address.GetEntityErrors());
        }

        [Test]
        public void StreetWithoutMinCharacterProvided()
        {
            Address address = new Address("ab", "abc", "abc", "abc", "abc", "abc", "abcdefgh");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Street: Street must be at least 3 characters.", address.GetEntityErrors());
        }

        [Test]
        public void CityNotProvided()
        {
            Address address = new Address("abc", "abc", "abc", string.Empty, "abc", "abc", "abcdefgh");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("City: City not provided.", address.GetEntityErrors());
        }

        [Test]
        public void CityWithoutMinCharacterProvided()
        {
            Address address = new Address("abc", "abc", "abc", "A", "abc", "abc", "abcdefgh");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("City: City must be at least 3 characters.", address.GetEntityErrors());
        }

        [Test]
        public void StateNotProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", string.Empty, "abc", "abcdefgh");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("State: State not provided.", address.GetEntityErrors());
        }

        [Test]
        public void StateWithoutMinCharacterProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "A", "abc", "abcdefgh");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("State: State must be at least 3 characters.", address.GetEntityErrors());
        }

        [Test]
        public void CountryNotProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", string.Empty, "abcdefgh");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Country: Country not provided.", address.GetEntityErrors());
        }

        [Test]
        public void CountryWithoutMinCharacterProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "A", "abcdefgh");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Country: Country must be at least 3 characters.", address.GetEntityErrors());
        }

        [Test]
        public void CountryWithMaxCharacterExceeded()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "abcdefg", "abcdefgh");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Country: Country must have a maximum of 4 characters.", address.GetEntityErrors());
        }
        [Test]
        public void ZipCodeNotProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "abc", string.Empty);
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("ZipCode: Zip code not provided.", address.GetEntityErrors());
        }

        [Test]
        public void ZipCodeWithoutMinCharacterProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "abc", "abcde");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("ZipCode: ZipCode must be at least 8 characters.", address.GetEntityErrors());
        }

        [Test]
        public void ZipCodeWithMaxCharacterExceeded()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "abcdefg", "abcdefghijlmno");
            address.CascadeMode = CascadeMode.Stop;
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("ZipCode: ZipCode must have a maximum of 9 characters.", address.GetEntityErrors());
        }

        [Test]
        public void AddressIsValid()
        {
            Address address = new Address("Rua ABC","S/N", "do lado", "Não existe", "Qualquer", "ABC", "ABCD5678");
            Assert.IsTrue(address.IsValid());
        }
    }
}
