using System.Text;

namespace ImageGenerator.Utilities
{
    public static class DisplayMessage
    {
        public const string EnterNumberMsg = "Enter number of images to generate:";
        public const string ExitProgramMsg = "exit";
        public const string ImageNotSavedMsg = "Failed to save some images";
        public const string IntegerValidationMsg = "Input must be an integer";
        public const string IntegerGrtThanZeroMsg = "Input must be an integer greater than zero";


        public static string AboutTheApp()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\nThis is a simple solution designed to generate images with different colors and text. \n");
            stringBuilder.Append($"All generated images are stored at \"{AppSettings.PathToDocuments}\" as configured in the App.Config\n");
            stringBuilder.Append("Code is written following the SINGLE RESPONSIBILITY PRINCIPLE with various UNIT TESTS\n\n");
            stringBuilder.Append("Type \"exit\" to close the program\n\n");

            return stringBuilder.ToString();
        }
    }
}
