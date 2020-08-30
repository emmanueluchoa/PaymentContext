using FluentValidation;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.Validator
{
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
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
