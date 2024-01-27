using Entities.Concrete;
using FluentValidation;
using System;
using System.IO;
using System.Drawing;
using System.Linq;

public class BlogValidator : AbstractValidator<Blog>
{
    private static readonly string[] ImageFormats = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".webp" };

    public BlogValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Başlık boş olamaz.")
            .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olmalıdır.")
            .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Başlık yalnızca harf, sayı ve boşluk içerebilir.");

        RuleFor(b => b.Content)
            .NotEmpty().WithMessage("İçerik boş olamaz.")
            .MinimumLength(100).WithMessage("İçerik en az 100 karakter içermelidir.")
            .Must(BeValidContent).WithMessage("İçerik geçerli değil.");

       RuleFor(b => b.UserId)
            .NotEmpty().WithMessage("Kullanıcı isimi boş olamaz.");

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
   
}