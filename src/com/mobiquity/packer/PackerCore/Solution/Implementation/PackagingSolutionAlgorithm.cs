
using Packer.Core.Models;
using Packer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Packer.Solution.Implementation
{
    public class PackagingSolutionAlgorithm : ISolutionAlgorithm
    {
        /// <summary>
        /// Algorithm method used to solve the Knapsack problem with item packaging
        /// The algorithm used is Recursion by Brute-Force algorithm.
        /// The Algorithm has complexity of O(2^n), but it is one of the most flexible and efficient solutions for decimal values
        /// This can be used for any decimal precision
        /// </summary>
        /// <param name="configuration">Package configuration containing: package maximum weight and items to chose from</param>
        /// <returns type="List<PackageItems>">Selected items for most optimal packaging</returns>
        /// 
        public List<PackageItem> Solve(PackageConfiguration configuration)
        {
            var result = SolveRecursive(configuration);
            return result.Items;

        }
        private static RecursiveSolutionResult SolveRecursive(PackageConfiguration configuration)
        {
            var packageMaxWeight = configuration.MaxWeight;
            var itemsCount = configuration.ItemOptions.Count;

            var itemOptions = configuration.ItemOptions;

            if (itemsCount == 0 || packageMaxWeight == 0)
                return new RecursiveSolutionResult();

            var lastItem = itemOptions.Last();
            var remainingItems = itemOptions.GetRange(0, itemsCount - 1);

            // If weight of the nth item is larger than max package capacity, do not include item
            if (lastItem.Weight > packageMaxWeight)
            {
                return SolveRecursive(new PackageConfiguration() { MaxWeight = packageMaxWeight, ItemOptions = remainingItems });
            }
            else
            {
                // Case(1) Return result where item is included in the subset
                var nthItemIncludedResult = SolveRecursive(new PackageConfiguration() { MaxWeight = packageMaxWeight - lastItem.Weight, ItemOptions = remainingItems });
                // Store included items and total cost and weight 
                nthItemIncludedResult.Cost += lastItem.Cost;
                nthItemIncludedResult.Items.Add(lastItem);
                nthItemIncludedResult.Weight += lastItem.Weight;

                // Case(2) Return result where item is not included in the subset
                var nthItemExcludedResult = SolveRecursive(new PackageConfiguration() { MaxWeight = packageMaxWeight, ItemOptions = remainingItems });

                // Return the maximum cost (object result) of two cases: nth item included, nth item not included
                return Max(nthItemIncludedResult, nthItemExcludedResult);
            }
        }

        private static RecursiveSolutionResult Max(RecursiveSolutionResult a, RecursiveSolutionResult b)
        {
            // If both subsets have the same cost, take the one with smaller weight 
            if (a.Cost == b.Cost) 
                return a.Weight <= b.Weight ? a : b;

            return a.Cost > b.Cost ? a : b;
        }
    }
}
