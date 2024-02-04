using Autofac.Features.Metadata;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
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
                if (string.IsNullOrEmpty(imagePath))
                {
                    return false;
                }

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
                var extension = Path.GetExtension(imagePath)?.ToLowerInvariant();

                return !string.IsNullOrEmpty(extension) && allowedExtensions.Contains(extension);
          }
        private bool IsImageFile(string filePath)
        {
            string[] allowedImageExtensions = { ".jpg", ".jpeg", ".png", ".heic", ".heif", ".webp" };

            if (!IsPathValid(filePath, allowedImageExtensions))
            {
                return false;
            }

            string extension = Path.GetExtension(filePath);

            if (allowedImageExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
            {
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

            return false;
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

