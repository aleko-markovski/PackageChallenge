using Packer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Packer
{
    public abstract class PackagingTemplate
    {
        public abstract List<PackageConfiguration> Extract(string filePath);
        public abstract void Validate(PackageConfiguration packagConfiguration);
        public abstract List<PackageItem> Solve(PackageConfiguration packagConfiguration);
        public abstract string Publish(List<PackageItem> items);
        public string Execute(string filePath)
        {
            var resultPublishes = new List<string>();

            var packageConfigurations = Extract(filePath);
            foreach (var packageConfiguration in packageConfigurations)
            {
                Validate(packageConfiguration);
                var result = Solve(packageConfiguration);
                resultPublishes.Add(Publish(result));
            }

            return string.Join(Environment.NewLine, resultPublishes);
        }
    }
}
