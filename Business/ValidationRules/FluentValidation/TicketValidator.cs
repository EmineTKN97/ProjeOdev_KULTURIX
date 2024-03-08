using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TicketValidator : AbstractValidator<TicketDTO>
    {
        public TicketValidator()
        {
            RuleFor(t => t.UserName)
           .NotEmpty().WithMessage("İsim alanı boş olamaz.");

            RuleFor(t => t.UserSurname)
                .NotEmpty().WithMessage("Soyisim alanı boş olamaz.");
            RuleFor(t => t.CityName)
             .NotEmpty().WithMessage("Şehir alanı boş olamaz.");
            RuleFor(t => t.DistrictName)
            .NotEmpty().WithMessage("İlçe alanı boş olamaz.");
            RuleFor(t => t.MuseumName)
                .NotEmpty().WithMessage("Müze alanı boş geçilemez");
            RuleFor(t => t.Time)
            .NotEmpty().WithMessage("Tarih alanı boş geçilemez")
            .Must(BeWithinWorkingHours).WithMessage("Tarih alanı çalışma saatleri dışında olmalıdır (09:00 - 16:00)");




        }
        private bool BeWithinWorkingHours(DateTime time)
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(16, 0, 0);

            TimeSpan inputTime = time.TimeOfDay;

            return inputTime >= startTime && inputTime <= endTime;
        }
    }

}
