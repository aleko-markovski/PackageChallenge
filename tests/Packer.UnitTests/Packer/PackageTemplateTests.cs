using FakeItEasy;
using Packer.ContentProvider;
using Packer.Services;
using Packer;
using System;
using Xunit;
using FluentAssertions;
using Packer.Core.Exceptions;
using Packer.Exceptions;

namespace Packer.UnitTests.Services
{
    public class PackageTemplateTests
    {
        private const string filePath = @"Resources/full_test_input";
        private const string invalidFilePath = @"Resources/invalid_file_path";
        private const string validationInvalidFile = @"Resources/validation_error_test_input";
        private const string invalidFormatFile = @"Resources/parse_error_input";
        private const string emptyFile = @"Resources/empty_file_input";

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

        [Fact]
        public void Pack_ThrowAPIExceptionParsingInnerException()
        {
            Action callingWithInvalidFilePath = () => Packaging.Pack(invalidFormatFile);

            callingWithInvalidFilePath.Should().Throw<APIException>().Where(e => e.Message.StartsWith("Parsing error:"));
        }

        [Fact]
        public void Pack_ThrowAPIExceptionValidationInnerException()
        {
            Action callingWithInvalidFilePath = () => Packaging.Pack(validationInvalidFile);

            callingWithInvalidFilePath.Should().Throw<APIException>().Where(e => e.Message.StartsWith("Validation error: "));
        }

        [Fact]
        public void Pack_ThrowAPIExceptionEmptyFileInnerException()
        {
            Action callingWithInvalidFilePath = () => Packaging.Pack(emptyFile);

            callingWithInvalidFilePath.Should().Throw<APIException>().Where(e => e.Message.StartsWith("Parsing error: "));
        }
    }
}
