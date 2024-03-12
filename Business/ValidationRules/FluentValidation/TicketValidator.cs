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
            .Must(BeWithinWorkingHours).WithMessage("Tarih alanı çalışma saatleri dışında olmamalıdır (09:00 - 16:00)");
            RuleFor(t => t.UserIdentity.ToString())
            .NotEmpty().WithMessage("T.C. Kimlik Numarası alanı boş olamaz.")
             .Length(11).WithMessage("T.C. Kimlik Numarası 11 karakter olmalıdır.");

            RuleFor(t => t.DateOfBirthYear)
                .NotEmpty().WithMessage("Doğum Yılı alanı boş olamaz.")
                .Must(BeOlderThan18).WithMessage("En az 18 yaşında olmalısınız.");


        }
        private bool BeWithinWorkingHours(DateTime time)
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(16, 0, 0);

            TimeSpan inputTime = time.TimeOfDay;

            return inputTime >= startTime && inputTime <= endTime;
        }
        private bool BeOlderThan18(int birthYear)
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            return age >= 18;
        }
    }

}
