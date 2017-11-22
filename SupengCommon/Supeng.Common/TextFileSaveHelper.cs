using System.IO;

namespace Supeng.Common
{
    public static class TextFileSaveHelper
    {
        public static void Save(this string fileName, string content, bool encrypt = false)
        {
            if (!encrypt)
            {
                File.WriteAllText(fileName, content);
            }
            else
            {
                //todo encrypt the content then save it;
            }
        }

        public static string Load(this string fileName, bool encrypt = false)
        {
            if (!File.Exists(fileName))
                return string.Empty;
            if (encrypt)
            {
                //todo: dencrypt
                return string.Empty;
            }
            else
            {
                return File.ReadAllText(fileName);
            }
        }
    }
}
