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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{

    public class BlogValidator : AbstractValidator<BlogDTO>
    {


        public BlogValidator()
        {
            RuleFor(b => b.Title)

            .NotEmpty().WithMessage("Başlık boş olamaz.")
            .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olmalıdır.")
            .Matches("^[a-zA-Z0-9\\p{L}\\p{P}\\p{S} ]+$").WithMessage("Başlık yalnızca harf, sayı, boşluk ve özel karakterler içerebilir.");

            RuleFor(b => b.Content)
                .NotEmpty().WithMessage("İçerik boş olamaz.")
                .MinimumLength(100).WithMessage("İçerik en az 100 karakter içermelidir.")
                .Must(content => Regex.IsMatch(content, @"^[a-zA-Z0-9\s!@#$%^&*()_+{}\[\]:;<>,.?/~\r\n]+$"))
                .WithMessage("İçerik geçerli değil. Özel karakterler içerebilir.");


        }


    }

}

