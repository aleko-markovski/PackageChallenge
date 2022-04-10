using Packer.Constants;
using Packer.Exceptions;
using Packer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Packer.Services.Implementation
{
    /// <summary>
    /// Service for validating package configuration given constraints
    /// 
    /// Known constraints from the physical world: 
    ///     Item weight cannot be 0; 
    ///     Item weight, Package weight, Item cost, and Package max weight cannot be negative number
    ///     
    /// CompareTo can be used in this method, but for better readibility I prefer the "old school" comparison
    /// </summary>
    public class ValidationService : IValidation
    {
        public void Validate(PackageConfiguration packageConfiguration)
        {
            ValidatePackageMaxWeight(packageConfiguration.MaxWeight);
            ValidateMaxNumberOfItems(packageConfiguration.ItemOptions);
            ValidateItemWeight(packageConfiguration.ItemOptions);
        }

        private void ValidatePackageMaxWeight(double packageMaxWeight)
        {
            if (!(0 <= packageMaxWeight && packageMaxWeight <= Constraints.PackageMaxWeight))
                throw new ValidationException("MaxWeight validation error");
        }

        private void ValidateMaxNumberOfItems(HashSet<PackageItem> items)
        {
            if (items.Count > Constraints.MaxNumberOfItems)
                throw new ValidationException("Max number of items validation error");
        }

        private void ValidateItemWeight(HashSet<PackageItem> items)
        {
            var itemsWithInvalidWeight = items.Where(x => !(0 < x.Weight && x.Weight <= Constraints.ItemMaxWeight));
            if (itemsWithInvalidWeight.Any())
                throw new ValidationException($"Invalid item(s) weight error: Fault Items: {string.Join(" ", itemsWithInvalidWeight.Select(x => x.ToString()))}");

        }
    }
}
