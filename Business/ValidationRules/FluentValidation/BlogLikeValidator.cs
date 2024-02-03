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

            RuleFor(bl => bl.Userid)
                .NotEmpty().WithMessage("Kullanıcı ID boş olamaz.")
                .Must(BeValidGuid).WithMessage("Geçerli bir Kullanıcı ID olmalıdır.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;

        }
    }
}
