using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Core.Utilities.Business
{
    public static class ImageHelper
    {
        public static string SaveImage(IFormFile file)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(directoryPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return uniqueFileName;
        }
        public static string UpdateImage(IFormFile file, string path)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            string fullPath = Path.Combine(directoryPath, path);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return SaveImage(file);

            }
            else
                throw new Exception("Dosya Bulunamadı!");

        }

        public static void DeleteImage(string path)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            string fullPath = Path.Combine(directoryPath, path);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else
                throw new Exception("Dosya Bulunamadı");
        }
    }
}
