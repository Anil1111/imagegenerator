using System.Threading.Tasks;

namespace ImageGenerator.BusinessLogic.Services.Image
{
    public interface IGenerateImageService
    {
        /// <summary>
        /// Generates a given number of images
        /// </summary>
        /// <param name="numberOfFiles">Number of images</param>
        /// <returns></returns>
        Task GenerateImages(string numberOfFiles);
    }
}
