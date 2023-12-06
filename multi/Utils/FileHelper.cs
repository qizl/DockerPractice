using System;
using System.IO;

namespace Utils
{
    public class FileHelper
    {
        public  string[] GetLocalFileNames()
        {
            var folder = Path.Combine(Environment.CurrentDirectory, "Files");
            if (Directory.Exists(folder))
                return Directory.GetFiles(folder);
            else
                return new string[0];
        }
    }
}
