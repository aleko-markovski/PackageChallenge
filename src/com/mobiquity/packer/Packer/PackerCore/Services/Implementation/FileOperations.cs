using Packer.ContentProvider;
using System.IO;

namespace Packer.Services
{
    public class FileOperations : IFileOperations
    {
        public string[] ReadAllLines(string path)
        {
            var fullPath = Path.GetFullPath(path);
            return File.ReadAllLines(fullPath);
        }
    }
}
