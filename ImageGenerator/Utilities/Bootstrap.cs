using ImageGenerator.BusinessLogic.Repository.ImageRepo;
using ImageGenerator.BusinessLogic.Services.CoreProcesser;
using ImageGenerator.BusinessLogic.Services.Image;
using ImageGenerator.BusinessLogic.Services.SaveFile;
using ImageGenerator.BusinessLogic.ValidationServices;
using SimpleInjector;

namespace ImageGenerator.Utilities
{
    /// <summary>
    /// Injects all dependencies 
    /// </summary>
    public class Bootstrap
    {
        public static Container container;

        /// <summary>
        /// Starts the dependency injection process
        /// </summary>
        public static void Start()
        {
            container = new Container();
            // Register your types, for instance:
            container.Register<ISaveFileService, SaveFileService>(Lifestyle.Singleton);
            container.Register<IGenerateImageService, GenerateImageService>(Lifestyle.Singleton);
            container.Register<IProcessImageService, ProcessImageService>(Lifestyle.Singleton);
            container.Register<IGenerateImageRepository, GenerateImageRepository>(Lifestyle.Singleton);
            container.Register<IUserInputValidationService, UserInputValidationService>(Lifestyle.Singleton);


            // Optionally verify the container.
            container.Verify();
        }
    }
}
