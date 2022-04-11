using Core.Constrains;
using Packer.Exceptions;
using Packer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Packer.ContentProvider
{
    /// <summary>
    /// Implementation of FileContentProvider
    /// </summary>
    public class PackageConfigurationContentProvider : FileContentProvider
    {
        private readonly IFileOperations _fileOperations;
        private readonly Regex linePattern;
        private readonly Regex itemPattern;
        public PackageConfigurationContentProvider(IFileOperations fileOperations)
        {
            _fileOperations = fileOperations;
            linePattern = new Regex(StringPatterns.LinePattern);
            itemPattern = new Regex(StringPatterns.ItemPattern);
        }

        protected override string[] Extract(string path)
        {
            return _fileOperations.ReadAllLines(path);
        }

        protected override List<PackageConfiguration> Transform(ICollection<string> contentLines)
        {
            if (contentLines.Count == 0)
                throw new ParsingException("Parsing error: Content lines enumerable parameter cannot be empty");

            var packagesList = new List<PackageConfiguration>();

            foreach (var line in contentLines)
            {
                ValidateLineFormat(line);
                var lineSections = GetSections(line);

                var itemsStrings = lineSections.ElementAt(1).Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var maxWeight = int.Parse(lineSections.ElementAt(0).Trim());
                var packageConfig = new PackageConfiguration() { MaxWeight = maxWeight };

                foreach (var itemString in itemsStrings)
                {
                    var matchedItem = GetPackageItemFromMatch(itemString, itemPattern);
                    packageConfig.ItemOptions.Add(matchedItem);
                }

                packagesList.Add(packageConfig);
            }

            return packagesList;
        }

        private void ValidateLineFormat(string lineString)
        {
            if (linePattern.Match(lineString).Value != lineString)
                throw new ParsingException($"Parsing error: Source string is not in the correct format. String value: {lineString}");
        }

        private string[] GetSections(string lineString)
        {
            var lineSections = lineString.Split(':', 2);

            if (lineSections.Length != 2)
                throw new ParsingException("Parsing error: Source string is not in the correct format");

            return lineSections;
        }

        private PackageItem GetPackageItemFromMatch(string itemString, Regex regex)
        {
            var match = regex.Match(itemString);

            if (!match.Success)
                throw new ParsingException($"Parsing error: Error while parsing item source string. Source value: { itemString }");

            var index = int.Parse(match.Groups["index"].Value);
            var weight = double.Parse(match.Groups["weight"].Value);
            var cost = int.Parse(match.Groups["cost"].Value);

            return new PackageItem(index, weight, cost);
        }
    }
}
