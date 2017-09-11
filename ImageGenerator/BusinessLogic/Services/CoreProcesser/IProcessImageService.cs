using ImageGenerator.BusinessLogic.Models;

namespace ImageGenerator.BusinessLogic.Services.CoreProcesser
{
    public interface IProcessImageService
    {
        /// <summary>
        /// Composes the image object with a file name and all the other file attributes
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns>ImageFile object</returns>
        ImageFile GenerateFile(string fileName);

        /// <summary>
        /// Generates image bytes as an array
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns>Byte Array</returns>
        byte[] CreateImage(string fileContent);
    }
}
