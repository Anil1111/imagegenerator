using ImageGenerator.BusinessLogic.Services.CoreProcesser;
using Moq;
using NUnit.Framework;

namespace ImageGenerator.Tests.Services
{
    [TestFixture]
    public class ProcessImageServiceTests
    {
        private IProcessImageService _coreProcessingService;

        [SetUp]
        public void SetUp()
        {
            _coreProcessingService = new ProcessImageService();

        }

        [TearDown]
        public void TearDown()
        {
            _coreProcessingService = null;
        }

        [Test]
        public void Test_CreateImage_Should_Throw_Any_Exception()
        {
            Assert.DoesNotThrow(() => _coreProcessingService.CreateImage(It.IsAny<string>()));
        }

        [Test]
        public void Test_CreateImage_Should_Return_ByteArray()
        {
            var result = _coreProcessingService.CreateImage(It.IsAny<string>());

            Assert.IsInstanceOf(typeof(byte[]), result);
        }

        [Test]
        public void Test_CreateImage_Should_Return_ByteArray_Of_Length_Greator_Than_Zero()
        {
            var result = _coreProcessingService.CreateImage(It.IsAny<string>());

            var contentLength = result.Length;

            Assert.That(contentLength, Is.GreaterThan(0));
        }
        
    }
}
