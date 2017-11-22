using System;
using System.IO;

namespace Supeng.Common
{
    public static class DirectoryHelper
    {
        public static string ImageDirectory => GetDirectory("Images");

        public static string DataDirectory => GetDirectory("Data");

        public static string LayoutDirectory => GetDirectory("Layouts");

        private static string GetDirectory(string folderName)
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }
    }
}