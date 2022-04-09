using Core.Constrains;
using Packer.Exceptions;
using Packer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Packer.ContentProvider
{
    public class PackageConfigurationContentProvider : FileContentProvider
    {
        private readonly IFileOperations _fileOperations;
        public PackageConfigurationContentProvider(IFileOperations fileOperations)
        {
            _fileOperations = fileOperations;
        }

        protected override string[] Extract(string path)
        {
            return _fileOperations.ReadAllLines(path);
        }

        protected override List<PackageConfiguration> Transform(ICollection<string> contentLines)
        {
            if (contentLines.Count == 0)
                throw new ParsingException("Content lines enumerable parameter cannot be empty");

            var packagesList = new List<PackageConfiguration>();

            foreach (var line in contentLines)
            {
                var lineSections = line.Split(':', 2);

                if (lineSections.Length != 2)
                    throw new ParsingException("Source string is not in the correct format");

                var itemsSourceStrings = lineSections.ElementAt(1).Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                // This regex pattern includes validation for digits
                var itemPattern = new Regex(StringPatterns.ItemPattern);

                var maxWeight = int.Parse(lineSections.ElementAt(0).Trim());
                var packageConfig = new PackageConfiguration() { MaxWeight = maxWeight };

                foreach (var itemSourceString in itemsSourceStrings)
                {
                    var match = itemPattern.Match(itemSourceString);

                    if (!match.Success)
                        throw new ParsingException($"Error while parsing item source string. Source value: { itemSourceString }");

                    var index = int.Parse(match.Groups["index"].Value);
                    var weight = double.Parse(match.Groups["weight"].Value);
                    var cost = int.Parse(match.Groups["cost"].Value);

                    packageConfig.ItemOptions.Add(new PackageItem(index, weight, cost));
                }

                packagesList.Add(packageConfig);
            }

            return packagesList;
        }
    }
}
