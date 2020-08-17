using FluentValidation.Results;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Shared.Interfaces
{
    public interface IValidateEntity<T> where T : class
    {
        bool IsValid();
        void Validate();
        string GetEntityErrors();
    }
}
