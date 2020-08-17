using FluentValidation;
using FluentValidation.Results;
using PaymentContext.Shared.Interfaces;
using System;
using System.Linq;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entity<T> : AbstractValidator<T>, IValidateEntity<T> where T : class
    {
        public Guid Id { get; private set; }
        private ValidationResult _validationResult { get; set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();

            if (null == this._validationResult)
                this._validationResult = new ValidationResult();

            this.Validate();
        }
        public bool IsValid()
        {
            this._validationResult = Validate(this as T);
            return this._validationResult.IsValid;
        }
        public abstract void Validate();
        public string GetEntityErrors()
        {
            string errorMessage = string.Empty;
            if (this._validationResult.Errors.Any())
                errorMessage = string.Join(", ", this._validationResult.Errors.Select(error => $"{error.PropertyName} : {error.ErrorMessage}"));

            return errorMessage;
        }
    }
}
