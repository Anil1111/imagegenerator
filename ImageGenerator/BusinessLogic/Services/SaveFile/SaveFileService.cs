using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using ImageGenerator.BusinessLogic.Models;
using ImageGenerator.Utilities;

namespace ImageGenerator.BusinessLogic.Services.SaveFile
{
    public class SaveFileService : ISaveFileService
    {

        public async Task<bool> Save(ImageFile file)
        {
           
            var fileInfo = new FileInfo(file.FileName);
            var fileExtension = fileInfo.Extension;

            var directory = AppSettings.PathToDocuments;
            if (!directory.IsDirectoryExist()) directory.CreateDirectory();
            var path = directory.FilePath(file.FileName);


            var ms = new MemoryStream(file.ImageData);
            var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, (int)ms.Length);
            var bytesInStream = new byte[ms.Length];
            ms.Read(bytesInStream, 0, bytesInStream.Length);

            await fileStream.WriteAsync(bytesInStream, 0, bytesInStream.Length);
            fileStream.Dispose();

            return true;
        }
    }
}
