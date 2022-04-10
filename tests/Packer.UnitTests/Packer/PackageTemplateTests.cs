using FakeItEasy;
using Packer.ContentProvider;
using Packer.Services;
using Packer;
using System;
using Xunit;
using FluentAssertions;
using Packer.Core.Exceptions;

namespace Packer.UnitTests.Services
{
    public class PackageTemplateTests
    {
        private const string filePath = @"Resources/full_test_input";
        private const string invalidFilePath = @"Resources/invalid_file_path";

        [Fact]
        public void Pack_Success()
        {
            var expectedResult = string.Join(Environment.NewLine, new string[] { "4", "-", "2,7", "8,9" });

            var result = Packaging.Pack(filePath);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Pack_ThrowAPIExceptionIfAnyProccessThrowsException()
        {
            Action callingWithInvalidFilePath = () => Packaging.Pack(invalidFilePath);

            callingWithInvalidFilePath.Should().Throw<APIException>();
        }
    }
}
