using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    internal class UserUpdateValidator : AbstractValidator<UserDTO>
    {

        public UserUpdateValidator()
        {
            RuleFor(u => u.Name)
              .NotEmpty().WithMessage("Ad alanı boş geçilemez.")
              .MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır.")
              .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir.");
            RuleFor(u => u.SurName)
              .NotEmpty().WithMessage("Soyad alanı boş geçilemez.")
              .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.")
              .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir.");
            RuleFor(u => u.Email)
               .NotEmpty().WithMessage("Email alanı boş geçilemez")
               .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(u => u.BirthDate)
                .NotEmpty().WithMessage("Lütfen doğum tarihinizi giriniz")
                .Must(birthDate => Is18OrOlder(birthDate)).WithMessage("Kullanıcı 18 yaşından küçük olamaz.");
        }
        private bool Is18OrOlder(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age >= 18;
        }
    }
}


