using Packer.Constants;
using Packer.Exceptions;
using Packer.Models;
using System;
using System.Collections.Generic;
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
            if (!(0 <= packageConfiguration.MaxWeight && packageConfiguration.MaxWeight <= Constraints.PackageMaxWeight))
                throw new ValidationException("MaxWeight validation error");
        }
    }
}
