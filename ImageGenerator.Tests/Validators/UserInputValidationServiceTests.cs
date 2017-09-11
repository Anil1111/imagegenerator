using System.Collections.Generic;
using ImageGenerator.BusinessLogic.ValidationServices;
using NUnit.Framework;

namespace ImageGenerator.Tests.Validators
{
    [TestFixture]
    public class UserInputValidationServiceTests
    {
        private IUserInputValidationService _inputValidationService;

        [SetUp]
        public void SetUp()
        {
            _inputValidationService = new UserInputValidationService();
        }

        [TearDown]
        public void TearDown()
        {
            _inputValidationService = null;
        }

        [Test]
        public void Test_ValidateUserInput_Should_Return_False_For_An_Empty_String()
        {
            var testValue = "";
            var result = _inputValidationService.ValidateUserInput(testValue, new List<string>());
            Assert.False(result);
        }

        [Test]
        public void Test_ValidateUserInput_Should_Return_False_For_If_Input_Is_Text_Or_Alphanumeric()
        {
            var testValue = "";
            var result = _inputValidationService.ValidateUserInput(testValue, new List<string>());
            Assert.False(result);
        }

        [Test]
        public void Test_ValidateUserInput_Should_Return_True_If_Text_Is_An_Integer_GreaterThan_Zero()
        {
            var testValue = "1";
            var result = _inputValidationService.ValidateUserInput(testValue, new List<string>());
            Assert.True(result);
        }

        [Test]
        public void Test_ValidateUserInput_Should_Return_False_If_Text_Is_An_Integer_LessThan_One()
        {
            var testValue = "0";
            var result = _inputValidationService.ValidateUserInput(testValue, new List<string>());
            Assert.False(result);
        }
    }
}
