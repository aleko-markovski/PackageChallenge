using Packer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Packer.Core.Models
{
    public class RecursiveSolutionResult
    {
        public double Weight { get; set; } = 0d;
        public int Cost { get; set; } = 0;
        public List<PackageItem> Items { get; set; } = new List<PackageItem>();
    }
}
