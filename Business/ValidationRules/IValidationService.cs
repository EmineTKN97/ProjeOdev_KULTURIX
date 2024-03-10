

using Core.Entities;
using FluentValidation.Results;

namespace Business.ValidationRules
{
    public interface IValidationService<T> where T : class, IEntity, new()
    {
        ValidationResult Validate(T entity);
    }
}