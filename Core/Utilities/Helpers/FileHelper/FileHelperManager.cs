using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile formfile, string root, string filePath)
        {
            Delete(filePath);
            return Upload(formfile, root);
        }

        public string Upload(IFormFile formfile, string root)
        {

            string filePath = Path.GetExtension(formfile.FileName);
            CheckImage(filePath);
            string fullPath = root + Guid.NewGuid().ToString() + filePath;
            CreateDictionary(root);

            CreateFileAndSave(formfile, fullPath);
            return fullPath;

        }

        private static void CreateFileAndSave(IFormFile formfile, string fullPath)
        {
            using (FileStream file = File.Create(fullPath))
            {
                formfile.CopyTo(file);
                file.Flush();

            }
        }

        private void CreateDictionary(string root)
        {
            if(!Directory.Exists(root)) Directory.CreateDirectory(root);
        }

        private void CheckImage(string filePath)
        {
            var extensions =new List<string>{ ".jpg", ".jpeg", ".png" };

            if (!extensions.Contains(filePath)){
                throw new Exception("Bu Dosya uzantısını yükleyemezsiniz");
            }
            
        }
    }
}
