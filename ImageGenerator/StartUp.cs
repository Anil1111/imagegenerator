using System;
using ImageGenerator.BusinessLogic.Services.Image;
using ImageGenerator.Utilities;

namespace ImageGenerator
{
    /// <summary>
    /// Application startUp
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// Starts and manages the program
        /// </summary>
        /// <param name="args"></param>
        public static void Start(string[] args)
        {
            Console.WriteLine(DisplayMessage.AboutTheApp());

            var service = Bootstrap.container.GetInstance<GenerateImageService>();

            while (true) // Loop indefinitely
            {

                Console.WriteLine(DisplayMessage.EnterNumberMsg);
                var input = Console.ReadLine(); // Get user input

                if (input == DisplayMessage.ExitProgramMsg) // If input is "exit", close program
                {
                    break;
                }

                service.GenerateImages(input).Wait();

            }
        }
    }
}
