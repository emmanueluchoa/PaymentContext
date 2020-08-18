using FluentValidation;
using FluentValidation.Results;
using PaymentContext.Shared.Interfaces;
using System.Linq;

namespace PaymentContext.Shared.ValueObjects
{
    public abstract class ValueObject<T> : AbstractValidator<T>, IValidateValueObject<T> where T : class
    {
        protected ValidationResult _validationResult { get; set; }
        public ValueObject()
        {
            if (null == this._validationResult)
                this._validationResult = new ValidationResult();

            this.Validate();
        }
        public string GetEntityErrors()
        {
            string errorMessage = string.Empty;
            if (this._validationResult.Errors.Any())
                errorMessage = string.Join(", ", this._validationResult.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}"));

            return errorMessage;
        }
        public abstract void Validate();
        public bool IsValid()
        {
            this._validationResult = Validate(this as T);
            return this._validationResult.IsValid;
        }
    }
}
