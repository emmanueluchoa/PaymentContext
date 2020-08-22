using FluentValidation;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public override void Validate()
        {
            ValidateCity();
            ValidateState();
            ValidateState();
            ValidateNumber();
            ValidateStreet();
            ValidateZipCode();
            ValidateCountry();
            ValidateNeighborhood();
        }
        void ValidateCountry()
        {
            RuleFor(address => address.Country)
                .NotEmpty().WithMessage("Country not provided.;");
        }
        void ValidateZipCode()
        {
            RuleFor(address => address.ZipCode)
                .NotEmpty().WithMessage("Zip code not provided.;");
        }
        void ValidateState()
        {
            RuleFor(address => address.State)
                .NotEmpty().WithMessage("State not provided.;");
        }
        void ValidateCity()
        {
            RuleFor(address => address.City)
                .NotEmpty().WithMessage("City not provided.;");
        }
        void ValidateNeighborhood()
        {
            RuleFor(address => address.Neighborhood)
                .NotEmpty().WithMessage("Neighborhood not provided.;");
        }
        void ValidateNumber()
        {
            RuleFor(address => address.Number)
                .NotEmpty().WithMessage("Number not provided.;");
        }
        void ValidateStreet()
        {
            RuleFor(address => address.Street)
                .NotEmpty().WithMessage("Street not provided.;");
        }
    }
}
