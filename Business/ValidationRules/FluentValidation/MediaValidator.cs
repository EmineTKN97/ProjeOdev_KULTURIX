using Autofac.Features.Metadata;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MediaValidator : AbstractValidator<MediaDTO>
    {
        private static readonly string[] ImageFormats = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".webp" };
        public MediaValidator()
        {
            RuleFor(m => m.ImagePath)
            .NotEmpty().WithMessage("Resim yolu boş olamaz.")
            .Must(BeAValidImagePath).WithMessage("Geçerli bir resim yolu belirtmelisiniz.");
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
                    var rawFormat = image.RawFormat.Guid.ToString();
                    return ImageFormats.Any(format => format.Equals(rawFormat, StringComparison.OrdinalIgnoreCase));
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
    }
    
}

