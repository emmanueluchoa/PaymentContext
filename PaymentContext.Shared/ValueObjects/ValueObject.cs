using FluentValidation.Results;
using System.Linq;

namespace PaymentContext.Shared.ValueObjects
{
    public abstract class ValueObject<T> where T : class
    {
        protected ValidationResult _validationResult { get; set; }
        public ValueObject()
        {
            if (null == this._validationResult)
                this._validationResult = new ValidationResult();
        }

        public string GetErrors()
        {
            string errorMessage = string.Empty;
            if (this._validationResult.Errors.Any())
                errorMessage = string.Join(", ", this._validationResult.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}"));

            return errorMessage;
        }

        public bool IsValid() =>
             this._validationResult.IsValid;

        public void SetValidationResult(ValidationResult result) =>
            this._validationResult = result;
    }
}
