using FluentValidation;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public EEmailType Type { get; private set; } = EEmailType.NotProvided;
        public string Address { get; private set; }

        public Email(string address, EEmailType type = EEmailType.NotProvided)
        {
            Type = type;
            Address = address;
        }
    }
}
