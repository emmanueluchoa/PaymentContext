using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject<Document>
    {
        public string Number { get; private set; }
        public EDocumentType Type { get; private set; } = EDocumentType.NotProvided;

        public Document(string number, EDocumentType type = EDocumentType.NotProvided)
        {
            Number = number;
            Type = type;
        }
    }
}
