using FakeItEasy;
using FluentAssertions;
using Packer.Exceptions;
using Packer.Models;
using Packer.Services;
using Packer.Services.Implementation;
using System.Collections.Generic;
using Xunit;

namespace Packer.UnitTests.Services
{
    public class ValidationTests
    {
        private readonly IValidation _sut;

        public ValidationTests()
        {
            _sut = new ValidationService();
        }

        public static IEnumerable<object[]> MaxWeightInvalidData
           => new object[][] {
                new object[] { 110 },
                new object[] { -10 }
           };

        [Theory]
        [MemberData(nameof(MaxWeightInvalidData))]
        public void ValidateMaxWeight_ThrowValidationException(int maxWeight)
        {
            var packageConfig = new PackageConfiguration()
            {
                MaxWeight = maxWeight,
                ItemOptions = new HashSet<PackageItem>()
                {
                    new PackageItem(1, 53.38, 45)
                }
            };

            _sut.Invoking(x => x.Validate(packageConfig)).Should().Throw<ValidationException>();
        }

        [Fact]
        public void ValidateNumberOfItems_ThrowValidationException()
        {
            var packageConfig = new PackageConfiguration()
            {
                MaxWeight = 81,
                ItemOptions = new HashSet<PackageItem>()
                {
                    new PackageItem(1, 53.38, 45),
                    new PackageItem(2, 53.38, 45),
                    new PackageItem(3, 53.38, 45),
                    new PackageItem(4, 53.38, 45),
                    new PackageItem(5, 53.38, 45),
                    new PackageItem(6, 53.38, 45),
                    new PackageItem(7, 53.38, 45),
                    new PackageItem(8, 53.38, 45),
                    new PackageItem(9, 53.38, 45),
                    new PackageItem(10, 53.38, 45),
                    new PackageItem(11, 53.38, 45),
                    new PackageItem(12, 53.38, 45),
                    new PackageItem(13, 53.38, 45),
                    new PackageItem(14, 53.38, 45),
                    new PackageItem(15, 53.38, 45),
                    new PackageItem(16, 53.38, 45)
                }
            };

            _sut.Invoking(x => x.Validate(packageConfig)).Should().Throw<ValidationException>();
        }

        public static IEnumerable<object[]> ItemWeightInvalidData
           => new object[][] {
                new object[] { -10 },
                new object[] { 0 },
                new object[] { 110 }
           };

        [Theory]
        [MemberData(nameof(ItemWeightInvalidData))]
        public void ValidateItemsWeight_ThrowValidationException(double weight)
        {
            var packageConfig = new PackageConfiguration()
            {
                MaxWeight = 81,
                ItemOptions = new HashSet<PackageItem>()
                {
                    new PackageItem(1, weight, 45),
                    new PackageItem(2, weight, 80)
                }
            };

            _sut.Invoking(x => x.Validate(packageConfig)).Should().Throw<ValidationException>();
        }

        public static IEnumerable<object[]> ItemCostInvalidData
           => new object[][] {
                        new object[] { -10 },
                        new object[] { 110 }
           };

        [Theory]
        [MemberData(nameof(ItemCostInvalidData))]
        public void ValidateItemsCost_ThrowValidationException(int cost)
        {
            var packageConfig = new PackageConfiguration()
            {
                MaxWeight = 81,
                ItemOptions = new HashSet<PackageItem>()
                {
                    new PackageItem(1, 12.5, cost),
                    new PackageItem(2, 50.36, cost)
                }
            };

            _sut.Invoking(x => x.Validate(packageConfig)).Should().Throw<ValidationException>();
        }

        public static IEnumerable<object[]> PackageValidData
           => new object[][] {
                                new object[] { 100.00, 100.00, 100 },
                                new object[] { 50.00, 50.00, 50 },
                                new object[] { 0, 10, 0}
           };

        [Theory]
        [MemberData(nameof(PackageValidData))]
        public void ValidateItemsCost_Success(double maxPackageWeight, double itemWeight, int itemCost)
        {
            var packageConfig = new PackageConfiguration()
            {
                MaxWeight = maxPackageWeight,
                ItemOptions = new HashSet<PackageItem>()
                {
                    new PackageItem(1, itemWeight, itemCost)
                }
            };

            _sut.Invoking(x => x.Validate(packageConfig)).Should().NotThrow<ValidationException>();
        }
    }
}
