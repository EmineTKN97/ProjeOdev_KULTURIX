using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class AnnouncementValidator:AbstractValidator<AnnouncementDTO>
    {
        public AnnouncementValidator()
        {
            RuleFor(a => a.AnnouncementTitle)
                    .NotEmpty().WithMessage("Başlık boş olamaz.")
                    .Length(5, 100).WithMessage("Başlık 5 ile 100 karakter arasında olmalıdır.");                
            RuleFor(a => a.AnnouncementContent)
                    .NotEmpty().WithMessage("İçerik boş olamaz.")
                    .Length(10, 1000).WithMessage("İçerik 10 ile 1000 karakter arasında olmalıdır.");
            RuleFor(a => a.CreateDate)
                    .LessThanOrEqualTo(DateTime.Now).WithMessage("Duyuru tarihi geçerli bir tarih olmalıdır.");
        }

    }
}
