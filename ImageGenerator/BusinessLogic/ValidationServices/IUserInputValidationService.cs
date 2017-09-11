using System.Collections.Generic;

namespace ImageGenerator.BusinessLogic.ValidationServices
{
    public interface IUserInputValidationService
    {
        /// <summary>
        /// Validates user input
        /// </summary>
        /// <param name="input">Read line value</param>
        /// <param name="errors">Error response</param>
        /// <returns>True if successful otherwise false</returns>
        bool ValidateUserInput(string input, List<string> errors);
    }
}
