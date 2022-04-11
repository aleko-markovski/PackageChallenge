using Packer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Packer
{
    /// <summary>
    /// Template class that defines ETL-ish process by executing the following steps
    /// Extract, Validate, Solve, Publish
    /// </summary>
    public abstract class PackagingTemplate
    {
        /// <summary>
        /// Reads content from file path as input parameter
        /// </summary>
        /// <param name="filePath">Path to file.</param>
        /// <returns></returns>
        public abstract List<PackageConfiguration> Extract(string filePath);
        /// <summary>
        /// Validate <c>PackageConfiguration</c> against defined constraints
        /// </summary>
        /// <param name="packagConfiguration"></param>
        public abstract void Validate(PackageConfiguration packagConfiguration);
        /// <summary>
        /// Solve package configuration problem <c></c>
        /// </summary>
        /// <param name="packagConfiguration"></param>
        /// <returns></returns>
        public abstract List<PackageItem> Solve(PackageConfiguration packagConfiguration);
        /// <summary>
        /// Generate specific string output format 
        /// </summary>
        /// <param name="items">Solution items</param>
        /// <returns>String formatted output</returns>
        public abstract string Publish(List<PackageItem> items);
        /// <summary>
        /// Execute steps for read and transform file content into data object, validate and solve each row of data, publish solutions to string formatted output  
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <returns></returns>
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
