
using Packer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Packer.Solution.Implementation
{
    public class PackagingSolutionAlgorithm : ISolutionAlgorithm
    {
        /// <summary>
        /// Algorithm method used to solve the Knapsack problem with item packaging
        /// The method time complexity is derived from the OrderBy -> ThenBy sorting method time complexity (QuickSort) which is on avarege O(N*logN)
        /// The LINQ OrderBy -> ThenBy method chain forms a single sort operation by multiple sort keys
        /// </summary>
        /// <param name="configuration">Package configuration containing package maximum weight and items to chose from</param>
        /// <returns type="List<PackageItems>">Selected items for most optimal packaging</returns>
        public List<PackageItem> Solve(PackageConfiguration configuration)
        {
            var sortedItemOptions = configuration.ItemOptions.OrderByDescending(x => x.Cost).ThenBy(x => x.Weight);

            double remainingWeight = configuration.MaxWeight;
            double resultValue = 0d;

            var selectedItems = new List<PackageItem>();

            foreach (var item in sortedItemOptions)
            {
                if (item.Weight <= remainingWeight)
                {
                    remainingWeight -= item.Weight;
                    resultValue += item.Cost;

                    selectedItems.Add(item);
                }

                // If the package is filled completly do not check the remaining items
                if (remainingWeight == 0)
                    break;
            }

            return selectedItems.OrderBy(x => x.Index).ToList();
        }
    }
}
