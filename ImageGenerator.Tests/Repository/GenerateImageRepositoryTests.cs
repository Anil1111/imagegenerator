using System.Threading.Tasks;
using ImageGenerator.BusinessLogic.Models;
using ImageGenerator.BusinessLogic.Repository.ImageRepo;
using ImageGenerator.BusinessLogic.Services.CoreProcesser;
using ImageGenerator.BusinessLogic.Services.SaveFile;
using Moq;
using NUnit.Framework;

namespace ImageGenerator.Tests.Repository
{
    [TestFixture]
    public class GenerateImageRepositoryTests
    {
        private Mock<IProcessImageService> _mockProcessImageService;
        private Mock<ISaveFileService> _mockSaveFileService;
        private IGenerateImageRepository _imageRepository;

        [SetUp]
        public void SetUp()
        {
            _mockProcessImageService = new Mock<IProcessImageService>();
            _mockSaveFileService = new Mock<ISaveFileService>();

            _imageRepository = new GenerateImageRepository(_mockSaveFileService.Object, _mockProcessImageService.Object);

            SetUpMocks();
        }

        [TearDown]
        public void TearDown()
        {
            _mockProcessImageService = null;
            _mockSaveFileService = null;
            _imageRepository = null;
        }


        [Test]
        public void Test_ProcessImages_Should_Throw_Any_Exception()
        {
            Assert.DoesNotThrowAsync(() => _imageRepository.ProcessImages(1));
        }


        [Test]
        public async Task Test_ProcessImages_Should_Call_IProcessImageService()
        {

            var result = await _imageRepository.ProcessImages(1);

            _mockProcessImageService.Verify(service => service.GenerateFile(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task Test_ProcessImages_Should_Call_ISaveFileService()
        {

            var result = await _imageRepository.ProcessImages(1);

            _mockSaveFileService.Verify(service => service.Save(It.IsAny<ImageFile>()), Times.Once);
        }

        [Test]
        public async Task Test_ProcessImages_Should_Call_ISaveFileService_The_Number_Of_Times_The_Loop_Runs()
        {

            var result = await _imageRepository.ProcessImages(5);

            _mockSaveFileService.Verify(service => service.Save(It.IsAny<ImageFile>()), Times.Exactly(5));
            _mockProcessImageService.Verify(service => service.GenerateFile(It.IsAny<string>()), Times.Exactly(5));
        }

        [Test]
        public async Task Test_ProcessImages_That_The_Returned_DataType_Is_Integer()
        {

            var result = await _imageRepository.ProcessImages(1);

            Assert.IsInstanceOf(typeof(int), result);
        }

        [Test]
        public async Task Test_ProcessImages_That_The_Number_Of_Processed_Images_Are_Equal_To_The_Passed_Parameter_Value()
        {

            var result = await _imageRepository.ProcessImages(2);

            Assert.AreEqual(2, result);
        }

        private void SetUpMocks()
        {
            _mockProcessImageService.Setup(service => service.GenerateFile(It.IsAny<string>())).Returns(It.IsAny<ImageFile>());
            _mockSaveFileService.Setup(service => service.Save(It.IsAny<ImageFile>())).ReturnsAsync(true);
        }
    }
}
