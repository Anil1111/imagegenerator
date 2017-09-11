using System.Threading.Tasks;
using ImageGenerator.BusinessLogic.Models;

namespace ImageGenerator.BusinessLogic.Services.SaveFile
{
    public interface ISaveFileService
    {
        /// <summary>
        /// Saves the image file to the local drive
        /// </summary>
        /// <param name="file"></param>
        /// <returns>True if successful other false</returns>
        Task<bool> Save(ImageFile file);
    }
}
