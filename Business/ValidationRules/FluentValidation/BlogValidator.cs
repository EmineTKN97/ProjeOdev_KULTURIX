using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{

    public class BlogValidator : AbstractValidator<BlogDTO>
    {
        private static readonly string[] ImageFormats = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".webp" };

        public BlogValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olmalıdır.")
                .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Başlık yalnızca harf, sayı ve boşluk içerebilir.");

            RuleFor(b => b.Description)
                .NotEmpty().WithMessage("İçerik boş olamaz.")
                .MinimumLength(100).WithMessage("İçerik en az 100 karakter içermelidir.")
                .Must(BeValidContent).WithMessage("İçerik geçerli değil.");


        }
        private bool BeValidContent(string content)
        {
            return !content.Contains("<script>");
        }
        private bool NotBeNull(Guid userId)
        {
            return userId != Guid.Empty;
        }

    }

}

