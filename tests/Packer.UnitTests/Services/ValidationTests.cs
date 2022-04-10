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

        public static IEnumerable<object[]> MaxWeightData
           => new object[][] {
                new object[] { 110 },
                new object[] { -10 }
           };

        [Theory]
        [MemberData(nameof(MaxWeightData))]
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
    }
}
