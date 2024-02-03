using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogLikeValidator : AbstractValidator<BlogLikeDTO>
    {
        public BlogLikeValidator()
        {

            RuleFor(bl => bl.Name)
                .NotEmpty().WithMessage("Kullanıcı ID boş olamaz.")
                .WithMessage("Geçerli bir Kullanıcı ID olmalıdır.");
            RuleFor(bl => bl.Surname)
              .NotEmpty().WithMessage("Kullanıcı ID boş olamaz.")
              .WithMessage("Geçerli bir Kullanıcı ID olmalıdır.");
        }

      
    }
}
