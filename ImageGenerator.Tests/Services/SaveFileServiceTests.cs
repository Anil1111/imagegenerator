using System.Threading.Tasks;
using System.Web;
using ImageGenerator.BusinessLogic.Models;
using ImageGenerator.BusinessLogic.Services.SaveFile;
using NUnit.Framework;

namespace ImageGenerator.Tests.Services
{
    [TestFixture]
    public class SaveFileServiceTests
    {
        private ISaveFileService _saveFile;
        private ImageFile _image;

        [SetUp]
        public void SetUp()
        {
            _saveFile = new SaveFileService();
            _image = GetImageFileObject();

        }

        [TearDown]
        public void TearDown()
        {
            _saveFile = null;
            _image = null;
        }

        [Test]
        public void Test_CreateImage_Should_Throw_Any_Exception()
        {
            var image = GetImageFileObject();
            Assert.DoesNotThrowAsync(() => _saveFile.Save(image));
        }

        [Test]
        public async Task Test_CreateImage_Should_Return_Boolean()
        {
            var result = await _saveFile.Save(_image);

            Assert.IsInstanceOf(typeof(bool), result);
        }
        [Test]
        public async Task Test_CreateImage_Should_Return_True()
        {
            var result = await _saveFile.Save(_image);

            Assert.AreEqual(true, result);
        }


        private static ImageFile GetImageFileObject()
        {
            var fileName = @"test file.png";
            var image = new ImageFile
            {
                FileName = fileName,
                MimeType = MimeMapping.GetMimeMapping(fileName),
                ImageData = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
            };

            return image;
        }
    }

}
