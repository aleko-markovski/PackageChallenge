using FakeItEasy;
using FluentAssertions;
using Packer.ContentProvider;
using Packer.Exceptions;
using Packer.Models;
using System.Collections.Generic;
using Xunit;

namespace Packer.UnitTests.Services
{
    public class PackageConfigurationContentProviderTests
    {
        private readonly FileContentProvider _contentProvider;
        private readonly IFileOperations _fileOperations;
        private const string _filePath = @"dummyFilePaht";
        public PackageConfigurationContentProviderTests()
        {
            _fileOperations = A.Fake<IFileOperations>();
            _contentProvider = new PackageConfigurationContentProvider(_fileOperations);
        }

        [Fact]
        public void LoadContentFromFile_Success()
        {
            var expectedResult = new List<PackageConfiguration>()
            {
                new PackageConfiguration()
                {
                    MaxWeight = 81,
                    ItemOptions = new List<PackageItem>()
                    {
                        new PackageItem(1, 53.38, 45),
                        new PackageItem(2, 88.62, 98),
                        new PackageItem(3, 78.48,3),
                        new PackageItem(4,72.30,76),
                        new PackageItem(5,30.18,9),
                        new PackageItem(6,46.34,48)
                    }
                }
            };

            A.CallTo(() => _fileOperations.ReadAllLines(A<string>.Ignored)).Returns(new string[] { "81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)" });

            var result = _contentProvider.Load(_filePath);

            result.Should().BeEquivalentTo(expectedResult);
        }

        public static IEnumerable<object[]> ItemsStrings
           => new object[][] {
                        new object[] { "81 : (a,53.38,€45)" },
                        new object[] { "81 : (1,a.38, €45)" },
                        new object[] { "81 : (-a,53.a, €45)" },
                        new object[] { "81 : (1,a.38,€45)" },
                        new object[] { "81 : (1,a,€45)" },
                        new object[] { "81 : (,53.38,€45)" },
                        new object[] { "81 : (1,,€45)" },
                        new object[] { "81 : (1,53.38,)" },
                        new object[] { "81 : (1,53.38,45)" },
                        new object[] { "81 : (,€45)" },
                        new object[] { "81 : (1,)" },
                        new object[] { "81 : (,53.38,)" },
                        new object[] { "81 : ()" },
           };


        [Theory]
        [MemberData(nameof(ItemsStrings))]
        public void LoadContentFromFile_ItemsParseException(string textLine)
        {
            A.CallTo(() => _fileOperations.ReadAllLines(A<string>.Ignored)).Returns(new string[] { textLine });

            _contentProvider.Invoking(x => x.Load(_filePath)).Should().Throw<ParsingException>();
        }

        public static IEnumerable<object[]> LineStrings
            => new object[][] {
                                new object[] { "81 : (1,53.38,€45)(2,88.62,€98)" },
                                new object[] { "81 : : (1,53.38,€45) (2,88.62,€98)" },
                                new object[] { "81: (1,53.38,€45)-(2,88.62,€98)" },
                                new object[] { "81 (1,53.38,€45) (2,88.62,€98)" },
                                new object[] { " : (1,53.38,€45) (2,88.62,€98)" },
                                new object[] { "81 : " },
            };


        [Theory]
        [MemberData(nameof(LineStrings))]
        public void LoadContentFromFile_LineParseException(string textLine)
        {
            A.CallTo(() => _fileOperations.ReadAllLines(A<string>.Ignored)).Returns(new string[] { textLine });

            _contentProvider.Invoking(x => x.Load(_filePath)).Should().Throw<ParsingException>();
        }

        [Fact]
        public void LoadContentFromFile_EmptyInputParseException()
        {
            A.CallTo(() => _fileOperations.ReadAllLines(A<string>.Ignored)).Returns(new string[] { });

            _contentProvider.Invoking(x => x.Load(_filePath)).Should().Throw<ParsingException>();
        }
    }
}
