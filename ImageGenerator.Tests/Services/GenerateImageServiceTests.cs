using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGenerator.BusinessLogic.Repository.ImageRepo;
using ImageGenerator.BusinessLogic.Services.Image;
using ImageGenerator.BusinessLogic.ValidationServices;
using Moq;
using NUnit.Framework;

namespace ImageGenerator.Tests.Services
{
    [TestFixture]
    public class GenerateImageServiceTests
    {
        private Mock<IGenerateImageRepository> _mockGenerateImageRepo;
        private Mock<IUserInputValidationService> _mockInputValidationService;
        private IGenerateImageService _generateImage;


        [SetUp]
        public void SetUp()
        {
            _mockGenerateImageRepo = new Mock<IGenerateImageRepository>();
            _mockInputValidationService = new Mock<IUserInputValidationService>();

            _generateImage = new GenerateImageService(_mockGenerateImageRepo.Object, _mockInputValidationService.Object);

        }

        [TearDown]
        public void TearDown()
        {
            _mockGenerateImageRepo = null;
            _mockInputValidationService = null;
            _generateImage = null;
        }

        [Test]
        public void Test_GenerateImages_Should_Throw_Any_Unhandled_Exception()
        {
            Assert.DoesNotThrowAsync(() => _generateImage.GenerateImages(""));
        }

        [Test]
        public async Task Test_GenerateImages_Should_Call_IUserInputValidationService()
        {
            await _generateImage.GenerateImages(It.IsAny<string>());
            _mockInputValidationService.Verify(service => service.ValidateUserInput(It.IsAny<string>(), It.IsAny<List<string>>()), Times.Once);
        }

        [Test]
        public async Task Test_GenerateImages_Should_Call_IGenerateImageRepository()
        {
            _mockInputValidationService.Setup(service => service.ValidateUserInput(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(true);
            await _generateImage.GenerateImages("1");
            _mockGenerateImageRepo.Verify(service => service.ProcessImages(It.IsAny<int>()), Times.Once);
        }
    }
}
