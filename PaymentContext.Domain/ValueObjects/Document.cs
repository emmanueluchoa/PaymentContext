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
            ValidateDocumentType();
            ValidateNumber();
            ValidateNumberByDocumentType();
        }

        public void ValidateNumber()
        {
            RuleFor(document => document.Number)
                .NotEmpty()
                .WithMessage("Document number not provided.");
        }

        public void ValidateNumberByDocumentType()
        {
            When(document => document.Type != EDocumentType.NotProvided, () =>
            {
                When(cnpjDocument => cnpjDocument.Type == EDocumentType.CNPJ, () =>
                {
                    RuleFor(doc => doc.Number)
                    .Length(14).WithMessage("CNPJ must have 14 characters.");
                }).Otherwise(() =>
                {
                    RuleFor(doc => doc.Number)
                    .Length(11).WithMessage("CPF must have 11 characters.");
                });
            });
        }
        public void ValidateDocumentType()
        {
            RuleFor(document => document.Type)
                .NotEqual(EDocumentType.NotProvided)
                .WithMessage("Document type not provided.");
        }
    }
}
