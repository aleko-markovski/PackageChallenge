using System;
using System.Collections.Generic;
using System.Text;

namespace Packer.Models
{
    public class PackageConfiguration
    {
        public double MaxWeight { get; set; }
        public List<PackageItem> ItemOptions { get; set; } = new List<PackageItem>();
    }
}
