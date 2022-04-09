using FluentAssertions;
using Packer.ContentProvider;
using Packer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Packer.UnitTests.Services
{
    public class PackageConfigurationContentProviderTests
    {
        private readonly FileContentProvider _contentProvider;
        private const string _validContentFilePath = @"Resources/valid_content_input";
        public PackageConfigurationContentProviderTests()
        {
            _contentProvider = new PackageConfigurationContentProvider();
        }

        [Fact]
        public void LoadContentFromFile()
        {
            var expectedResult = new List<PackageConfiguration>()
            {
                new PackageConfiguration()
                {
                    MaxWeight = 81,
                    ItemOptions = new HashSet<PackageItem>()
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

            var result = _contentProvider.Load(_validContentFilePath);
            
            result.Should().BeEquivalentTo(expectedResult);
        }

    }
}
