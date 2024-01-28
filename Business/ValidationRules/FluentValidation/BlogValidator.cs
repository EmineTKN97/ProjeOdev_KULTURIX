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
    /*
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

            RuleFor(bc => bc.UserId)
                  .NotEmpty().WithMessage("Kullanıcı isimi boş olamaz.")
                  .Must(NotBeNull).WithMessage("Yorum eklemek için giriş yapmalısınız.");

            RuleFor(b => b.ImagePath)
                .NotEmpty().WithMessage("Resim yolu boş olamaz.")
                .Must(BeAValidImagePath).WithMessage("Kullandığınız resim formatı geçersiz veya dosya bir resim değil.");
        }

        private bool BeValidContent(string content)
        {

            return !content.Contains("<script>");
        }

        private bool BeAValidImagePath(string imagePath)
        {
            return !string.IsNullOrEmpty(imagePath) && IsImageFile(imagePath);
        }


        private bool IsImageFile(string filePath)
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".heic", ".heif", ".webp" };

            if (!IsPathValid(filePath, allowedExtensions))
            {
                return false;
            }

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    return ContainsImageFormat(stream);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ContainsImageFormat(Stream stream)
        {
            try
            {
                using (var image = Image.FromStream(stream))
                {
                    return ImageFormats.Any(format => format.Equals(image.RawFormat.Guid.ToString(), StringComparison.OrdinalIgnoreCase));
                }
            }
            catch
            {
                return false;
            }
        }

        private bool IsPathValid(string filePath, string[] allowedExtensions)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return false;
            }

            string extension = Path.GetExtension(filePath);

            return !string.IsNullOrEmpty(extension) && allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }
        private bool NotBeNull(Guid userId)
        {
            return userId != Guid.Empty;
        }

    }
*/
}

