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
           .Length(5, 100).WithMessage("Blog başlığı 5 ile 100 karakter arasında olmalıdır.");
            RuleFor(b => b.Content)
             .NotEmpty().WithMessage("İçerik boş olamaz.")
             .Length(50, 1000).WithMessage("Blog içeriği 50 ile 1000 karakter arasında olmalıdır.");


        }


    }

}

