using FluentValidation.Results;
using System;
using System.Linq;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entity<T> where T : class
    {
        public Guid Id { get; private set; }
        private ValidationResult _validationResult { get; set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();

            if (null == this._validationResult)
                this._validationResult = new ValidationResult();
        }

        public string GetValidationErrors()
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
