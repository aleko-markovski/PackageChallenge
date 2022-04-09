using Packer.Models;
using System.Collections.Generic;
using System.IO;

namespace Packer.ContentProvider
{
    public abstract class FileContentProvider
    {
        public string[] Extract(string path)
        {
            var fullPath = Path.GetFullPath(path);
            return File.ReadAllLines(fullPath);
        }
        protected abstract List<PackageConfiguration> Transform(ICollection<string> contentLines);

        public List<PackageConfiguration> Load(string filePath)
        {
            var fileContentLines = Extract(filePath);
            return Transform(fileContentLines);
        }
    }
}
