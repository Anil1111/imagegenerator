using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using ImageGenerator.BusinessLogic.Models;

namespace ImageGenerator.BusinessLogic.Services.CoreProcesser
{
    public class ProcessImageService : IProcessImageService
    {

        public ImageFile GenerateFile(string fileName)
        {
            string fileContent = $"I was generated on: {DateTime.Now:F}";

            var path = Path.GetTempPath() + fileName;

            var file = new ImageFile();
            // Create the file.
            using (FileStream fs = File.Create(path))
            {

                Byte[] info = CreateImage(fileContent);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);

                file.FileName = fileName;
                file.MimeType = MimeMapping.GetMimeMapping(fs.Name);
                file.ImageData = info;

            }

            if (File.Exists(path)) File.Delete(path);

            return file;
        }

        public byte[] CreateImage(string fileContent)
        {
            SizeF imageSizeF = new SizeF(1000.5F, 1000.8F);

            using (var bmpOut = new Bitmap((int)imageSizeF.Width, (int)imageSizeF.Height))
            {
                Graphics g = Graphics.FromImage(bmpOut);

                Font font = new Font(FontFamily.GenericMonospace, 20F, FontStyle.Italic);

                SizeF size = g.MeasureString(fileContent, font);

                int x = Convert.ToInt32(((int)imageSizeF.Width / 2) - (size.Width / 2));
                int y = Convert.ToInt32(((int)imageSizeF.Height / 2) - (size.Height / 2));

                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Color backColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                var rectangle = new Rectangle(0, 0, (int)imageSizeF.Width, (int)imageSizeF.Height);
                LinearGradientBrush gradientBrush = new LinearGradientBrush(rectangle, randomColor, backColor, GetRandomNumber(0, 359));
                g.FillRectangle(gradientBrush, 0, 0, (int)imageSizeF.Width, (int)imageSizeF.Height);
                g.DrawString(fileContent, font, new SolidBrush(Color.Black), x, y);
                
                ImageConverter converter = new ImageConverter();
                Byte[] info = (byte[])converter.ConvertTo(bmpOut, typeof(byte[]));

                return info;

            }
        }

        private static int GetRandomNumber(int minimum, int maximum)
        {
            Random random = new Random();
            return random.Next() * (maximum - minimum) + minimum;
        }



       
    }
}
