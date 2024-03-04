using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper
{
   public static class FileHelper
    {
        public static string GenerateFileName(IFormFile file)
        {
			if (file == null || file.Length == 0 || string.IsNullOrEmpty(file.FileName))
			{
				throw new ArgumentNullException("file", "Dosya boş veya geçersiz.");
			}
			string[] allowedExtensions = { ".jpg", ".jpeg", ".png","webp"};

			string fileExtension = Path.GetExtension(file.FileName);
			if (!allowedExtensions.Contains(fileExtension.ToLower()))
			{
				throw new NotSupportedException("Desteklenmeyen dosya uzantısı.");
			}
			string uniqueFileName = Guid.NewGuid().ToString();
			return uniqueFileName + fileExtension;
		}
        
    }
}
