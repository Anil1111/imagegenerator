using System.Collections.Generic;
using System.Linq;
using ImageGenerator.BusinessLogic.Validators;

namespace ImageGenerator.BusinessLogic.ValidationServices
{
    public class UserInputValidationService : IUserInputValidationService
    {
        public bool ValidateUserInput(string input, List<string> errors)
        {
            var validator = new InputValidator();
            var result = validator.Validate(input);
            errors.AddRange(result.Errors.Select(error => error.ErrorMessage));
            return result.IsValid;
        }
    }
}
