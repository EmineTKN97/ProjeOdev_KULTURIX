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
            string uniqueFileName = Guid.NewGuid().ToString();
            string fileExtension = Path.GetExtension(file.FileName);
            return uniqueFileName + fileExtension;
        }
        
    }
}
