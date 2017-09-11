using System;
using System.Threading.Tasks;
using ImageGenerator.BusinessLogic.Services.CoreProcesser;
using ImageGenerator.BusinessLogic.Services.SaveFile;
using ImageGenerator.Utilities;

namespace ImageGenerator.BusinessLogic.Repository.ImageRepo
{
    public class GenerateImageRepository : IGenerateImageRepository
    {
        private readonly ISaveFileService _saveFileService;
        private readonly IProcessImageService _coreProcessingService;

        public GenerateImageRepository(ISaveFileService saveFileService, IProcessImageService coreProcessingService)
        {
            _saveFileService = saveFileService;
            _coreProcessingService = coreProcessingService;
        }

        public async Task<int> ProcessImages(int numberOfFiles)
        {
            var imageCounter = 0;
            while (true)
            {
                imageCounter++;
                var fileName = $@"{Guid.NewGuid()}.png";

                var file = _coreProcessingService.GenerateFile(fileName);

                var saveResult = await _saveFileService.Save(file);
                if (!saveResult)
                {
                    Console.WriteLine(DisplayMessage.ImageNotSavedMsg);
                    imageCounter--;
                    break;
                }

                if (imageCounter == numberOfFiles) break;
            }

            return imageCounter;
        }
    }
}
