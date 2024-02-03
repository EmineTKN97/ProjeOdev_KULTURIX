using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ChangePasswordValidator
    { 
      public static ValidationResult ValidateChangePassword(string currentPassword, string newPassword)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrEmpty(currentPassword))
            {
                validationResult.Errors.Add("Mevcut şifre boş geçilemez.");
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                validationResult.Errors.Add("Yeni şifre boş geçilemez.");
            }
            else
            {
                if (newPassword.Length < 6)
                {
                    validationResult.Errors.Add("Yeni şifre en az 6 karakter olmalıdır.");
                }

                if (!newPassword.Any(char.IsUpper))
                {
                    validationResult.Errors.Add("Yeni şifre en az bir büyük harf içermelidir.");
                }

                if (!newPassword.Any(char.IsLower))
                {
                    validationResult.Errors.Add("Yeni şifre en az bir küçük harf içermelidir.");
                }

                if (!newPassword.Any(char.IsDigit))
                {
                    validationResult.Errors.Add("Yeni şifre en az bir rakam içermelidir.");
                }
            }

            return validationResult;
        }
    }

    public class ValidationResult
    {
        public List<string> Errors { get; set; } = new List<string>();

        public bool IsValid => Errors.Count == 0;
    }
}
