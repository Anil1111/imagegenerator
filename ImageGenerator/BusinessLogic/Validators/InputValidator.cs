using FluentValidation;
using ImageGenerator.Utilities;

namespace ImageGenerator.BusinessLogic.Validators
{
    public class InputValidator : AbstractValidator<string>
    {
        public InputValidator()
        {
            RuleFor(input => input).NotEmpty();
            RuleFor(input => input).Must(BeAValidInteger).WithMessage(DisplayMessage.IntegerValidationMsg);
            RuleFor(input => input).Must(BeAValidIntegerGreaterThanZero).WithMessage(DisplayMessage.IntegerGrtThanZeroMsg);

        }

        private bool BeAValidInteger(string input)
        {
            return int.TryParse(input, out int _);
        }

        private bool BeAValidIntegerGreaterThanZero(string input)
        {
            int.TryParse(input, out int result);
            return result > 0;
        }
    }

}
