using Packer.Models;
using System.Collections.Generic;

namespace Packer.Solution
{
    public interface ISolutionAlgorithm
    {
        public List<PackageItem> Solve(PackageConfiguration configuration);
    }
}
