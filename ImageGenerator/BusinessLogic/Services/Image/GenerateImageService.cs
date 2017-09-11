using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImageGenerator.BusinessLogic.Repository.ImageRepo;
using ImageGenerator.BusinessLogic.ValidationServices;
using ImageGenerator.Utilities;
using NLog;

namespace ImageGenerator.BusinessLogic.Services.Image
{
    public class GenerateImageService : IGenerateImageService
    {
        private readonly IGenerateImageRepository _generateImageRepo;
        private readonly IUserInputValidationService _inputValidationService;
        private readonly Logger _logger;

        public GenerateImageService(IGenerateImageRepository generateImageRepo, IUserInputValidationService inputValidationService)
        {
            _generateImageRepo = generateImageRepo;
            _inputValidationService = inputValidationService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Generates a given number of images
        /// </summary>
        /// <param name="numberOfFiles">Number of images</param>
        /// <returns></returns>
        public async Task GenerateImages(string numberOfFiles)
        {
            try
            {
                var errors = new List<string>();
                var validationResult = _inputValidationService.ValidateUserInput(numberOfFiles, errors);
                if (!validationResult)
                {
                    Console.WriteLine(errors.ToJson());
                    return;
                }

                int.TryParse(numberOfFiles, out int result);

                var generatedImages = await _generateImageRepo.ProcessImages(result);

                Console.WriteLine($"{generatedImages} image(s) have been generated and stored at {AppSettings.PathToDocuments}");

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

    }
}
