using System.Threading.Tasks;

namespace ImageGenerator.BusinessLogic.Repository.ImageRepo
{
    public interface IGenerateImageRepository
    {
        /// <summary>
        /// Process the given number of images
        /// </summary>
        /// <param name="numberOfFiles">Number of images to process</param>
        /// <returns>Number of processed images</returns>
        Task<int> ProcessImages(int numberOfFiles);
    }
}
