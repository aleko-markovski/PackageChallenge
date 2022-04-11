using Packer.Models;
using System.Collections.Generic;
using System.IO;

namespace Packer.ContentProvider
{
    /// <summary>
    /// Template class for loading data from file and transforming to data object
    /// </summary>
    public abstract class FileContentProvider
    {
        /// <summary>
        /// Loda content from file as array of strings
        /// </summary>
        /// <param name="path">Path of a file</param>
        /// <returns>Array of string for each row in the file</returns>
        protected abstract string[] Extract(string path);
        /// <summary>
        /// Transform array of strings into collection of data objects
        /// </summary>
        /// <param name="contentLines"></param>
        /// <returns>Collection of data objects: <c>PackageConfiguration</c></returns>
        protected abstract List<PackageConfiguration> Transform(ICollection<string> contentLines);

        public List<PackageConfiguration> Load(string filePath)
        {
            var fileContentLines = Extract(filePath);
            return Transform(fileContentLines);
        }
    }
}
