using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    internal class AdminUpdateValidator : AbstractValidator<AdminDTO>
    {
        public AdminUpdateValidator()
        {
            RuleFor(a => a.LastName)
             .NotEmpty().WithMessage("Ad alanı boş geçilemez.")
             .MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır.")
             .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir.");
            RuleFor(a => a.FirstName)
              .NotEmpty().WithMessage("Soyad alanı boş geçilemez.")
              .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.")
              .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir.");
            RuleFor(a => a.Email)
               .NotEmpty().WithMessage("Email alanı boş geçilemez")
               .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
        }
    }

}
