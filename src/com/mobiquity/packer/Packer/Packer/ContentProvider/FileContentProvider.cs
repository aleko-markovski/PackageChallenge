using Packer.Models;
using System.Collections.Generic;
using System.IO;

namespace Packer.ContentProvider
{
    public abstract class FileContentProvider
    {
        protected abstract string[] Extract(string path);
        protected abstract List<PackageConfiguration> Transform(ICollection<string> contentLines);

        public List<PackageConfiguration> Load(string filePath)
        {
            var fileContentLines = Extract(filePath);
            return Transform(fileContentLines);
        }
    }
}
