using Packer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Packer.ContentProvider
{
    public class PackageConfigurationContentProvider : FileContentProvider
    {
        protected override string[] Extract(string path)
        {
            throw new NotImplementedException();
        }

        protected override List<PackageConfiguration> Transform(ICollection<string> contentLines)
        {
            throw new NotImplementedException();
        }
    }
}
