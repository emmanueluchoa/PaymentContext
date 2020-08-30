using FluentValidation;
using NUnit.Framework;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    public class AddressTest
    {
        private AddressValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new AddressValidator();
        }

        [Test]
        public void StreetNotProvided()
        {
            Address address = new Address(string.Empty, "abc", "abc", "abc", "abc", "abc", "abcdefgh");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Street: Street not provided.", address.GetErrors());
        }

        [Test]
        public void StreetWithoutMinCharacterProvided()
        {
            Address address = new Address("ab", "abc", "abc", "abc", "abc", "abc", "abcdefgh");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Street: Street must be at least 3 characters.", address.GetErrors());
        }

        [Test]
        public void CityNotProvided()
        {
            Address address = new Address("abc", "abc", "abc", string.Empty, "abc", "abc", "abcdefgh");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("City: City not provided.", address.GetErrors());
        }

        [Test]
        public void CityWithoutMinCharacterProvided()
        {
            Address address = new Address("abc", "abc", "abc", "A", "abc", "abc", "abcdefgh");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("City: City must be at least 3 characters.", address.GetErrors());
        }

        [Test]
        public void StateNotProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", string.Empty, "abc", "abcdefgh");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("State: State not provided.", address.GetErrors());
        }

        [Test]
        public void StateWithoutMinCharacterProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "A", "abc", "abcdefgh");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("State: State must be at least 3 characters.", address.GetErrors());
        }

        [Test]
        public void CountryNotProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", string.Empty, "abcdefgh");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Country: Country not provided.", address.GetErrors());
        }

        [Test]
        public void CountryWithoutMinCharacterProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "A", "abcdefgh");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Country: Country must be at least 3 characters.", address.GetErrors());
        }

        [Test]
        public void CountryWithMaxCharacterExceeded()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "abcdefg", "abcdefgh");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("Country: Country must have a maximum of 4 characters.", address.GetErrors());
        }
        [Test]
        public void ZipCodeNotProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "abc", string.Empty);
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("ZipCode: Zip code not provided.", address.GetErrors());
        }

        [Test]
        public void ZipCodeWithoutMinCharacterProvided()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "abc", "abcde");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("ZipCode: ZipCode must be at least 8 characters.", address.GetErrors());
        }

        [Test]
        public void ZipCodeWithMaxCharacterExceeded()
        {
            Address address = new Address("abc", "abc", "abc", "abc", "abc", "abcdefg", "abcdefghijlmno");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsFalse(address.IsValid());
            Assert.AreEqual("ZipCode: ZipCode must have a maximum of 9 characters.", address.GetErrors());
        }

        [Test]
        public void AddressIsValid()
        {
            Address address = new Address("Rua ABC", "S/N", "do lado", "Não existe", "Qualquer", "ABC", "ABCD5678");
            _validator.CascadeMode = CascadeMode.Stop;
            address.SetValidationResult(_validator.Validate(address));
            Assert.IsTrue(address.IsValid());
        }
    }
}
