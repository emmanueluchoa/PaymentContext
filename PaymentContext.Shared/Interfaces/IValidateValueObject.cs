using FluentValidation.Results;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Shared.Interfaces
{
    public interface IValidateValueObject<T> where T : class
    {
        bool IsValid();
        void Validate();
        string GetEntityErrors();
    }
}
