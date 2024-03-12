using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogCommentValidator : AbstractValidator<BlogCommentDTO>
    {
        public BlogCommentValidator()
        {
            RuleFor(bc => bc.CommentDetail)
           .NotEmpty().WithMessage("Yorum içeriği boş olamaz.")
            .Length(5, 1000).WithMessage("Yorum içeriği 5 ile 1000 karakter arasında olmalıdır.");
            RuleFor(bc => bc.UserName)
                .NotEmpty().WithMessage("Kullanıcı isimi boş olamaz.")
               .WithMessage("Yorum eklemek için giriş yapmalısınız.");
            RuleFor(bc => bc.UserSurname)
             .NotEmpty().WithMessage("Kullanıcı isimi boş olamaz.")
            .WithMessage("Yorum eklemek için giriş yapmalısınız.");
            RuleFor(bc => bc.CommentTitle)
            .NotEmpty().WithMessage("Yorum başlığı boş olamaz.")
             .Length(5, 100).WithMessage("Yorum başlığı 5 ile 100 karakter arasında olmalıdır.");

        }

    }
   
}

