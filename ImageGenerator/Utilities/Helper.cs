using System.IO;

namespace ImageGenerator.Utilities
{
    public static class Helper
    {

        public static void CreateDirectory(this string filePath)
        {
            Directory.CreateDirectory(filePath);
        }

        public static bool IsDirectoryExist(this string filePath)
        {
            return Directory.Exists(filePath);
        }

        public static bool IsFileExist(this string filePath)
        {
            return File.Exists(filePath);
        }

        public static string FilePath(this string filePath, string fileName)
        {
            return Path.Combine(filePath, fileName);
        }

    }
}
