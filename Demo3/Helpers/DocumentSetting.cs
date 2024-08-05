using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Demo3.Helpers
{
    public class DocumentSetting
    {
        public static string UploadFile(IFormFile file , string FolderName)
        {
            //1. Create The Folder Path 
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);

            //2. Create an Unique File Name 
            string FileName = $"{Guid.NewGuid()}{file.FileName}";

            //3. Create The File Path 
            string FilePath = Path.Combine(FolderPath, FileName);

            //4. Save the file as Stream 
           using  var fileStream = new FileStream(FilePath, FileMode.Create);

            // Copy the file Recived at the fileStream 
            file.CopyTo(fileStream);

            // Retuen the file Name to save It in the datebase 
            return FileName;


        }

        public static void DeleteFile (string fileName , string FolderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName,fileName);

            if(File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

        }

    }
}
