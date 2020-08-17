using FluentValidation;
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
        public override void Validate()
        {
            ValidateNumber();
            ValidateDocumentType();
        }
        public void ValidateNumber()
        {
            RuleFor(document => document.Number)
                .NotEmpty()
                .WithMessage("Document number not provided.")
                .When(document => document.Type == EDocumentType.CNPJ).Length(14)
                .When(document => document.Type == EDocumentType.CPF).Length(11);
        }
        public void ValidateDocumentType()
        {
            RuleFor(document => document.Type)
                .NotEmpty()
                .WithMessage("Document type not provided.")
                .NotEqual(EDocumentType.NotProvided)
                .WithMessage("Document type not provided.");
        }
    }
}
