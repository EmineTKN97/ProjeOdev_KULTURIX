using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Reflection;

namespace Business.ValidationRules.FluentValidation
{
    public class ValidationManager<T> : IValidationService<T> where T : class, IEntity, new()
    {
        private AbstractValidator<T> GetValidator()
        {
            var validatorType = Assembly.GetExecutingAssembly()
                                       .GetTypes()
                                       .FirstOrDefault(t => t.Name == $"{typeof(T).Name}Validator");

            if (validatorType == null)
            {
                throw new InvalidOperationException($"Validator for {typeof(T).Name} not found.");
            }

            var validator = (AbstractValidator<T>)Activator.CreateInstance(validatorType);
            return validator;
        }

     

        global::FluentValidation.Results.ValidationResult IValidationService<T>.Validate(T entity)
        {
            AbstractValidator<T> validator = GetValidator();
            return ValidationTool.Validate(validator, entity);
        }
    }
}