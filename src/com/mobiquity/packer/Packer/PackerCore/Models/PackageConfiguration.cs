using System;
using System.Collections.Generic;
using System.Text;

namespace Packer.Models
{
    public class PackageConfiguration
    {
        public double MaxWeight { get; set; }
        public HashSet<PackageItem> ItemOptions { get; set; } = new HashSet<PackageItem>();
    }
}
