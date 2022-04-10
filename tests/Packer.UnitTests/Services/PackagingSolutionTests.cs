using FluentAssertions;
using Packer.Models;
using Packer.Solution;
using Packer.Solution.Implementation;
using System.Collections.Generic;
using Xunit;

namespace Packer.UnitTests.Services
{
    public class PackagingSolutionTests
    {
        private readonly ISolutionAlgorithm _sut;

        public PackagingSolutionTests()
        {
            _sut = new PackagingSolutionAlgorithm();
        }

        public static IEnumerable<object[]> TestCases
           => new object[][] {
                new object[] {
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
                    },
                    new List<PackageItem>()
                    {
                        new PackageItem(4,72.30,76)
                    }
                },
                new object[] {
                    new PackageConfiguration()
                    {
                        MaxWeight = 8,
                        ItemOptions = new List<PackageItem>()
                        {
                            new PackageItem(1, 15.3, 34)
                        }
                    },
                    new List<PackageItem>(){}
                },
                new object[] {
                    new PackageConfiguration()
                    {
                        MaxWeight = 75,
                        ItemOptions = new List<PackageItem>()
                        {
                            new PackageItem(1, 85.31, 29),
                            new PackageItem(2, 14.55, 74),
                            new PackageItem(3, 3.98,16),
                            new PackageItem(4,26.24,55),
                            new PackageItem(5,63.69,52),
                            new PackageItem(6,76.25,75),
                            new PackageItem(7,60.02,74),
                            new PackageItem(8,93.18,35),
                            new PackageItem(9,89.95,78)
                        }
                    },
                    new List<PackageItem>()
                    {
                        new PackageItem(2, 14.55, 74),
                        new PackageItem(7,60.02,74)

                    }
                },
                new object[] {
                    new PackageConfiguration()
                    {
                        MaxWeight = 56,
                        ItemOptions = new List<PackageItem>()
                        {
                            new PackageItem(1, 90.72, 13),
                            new PackageItem(2, 33.80, 48),
                            new PackageItem(3, 43.15,10),
                            new PackageItem(4,37.97,16),
                            new PackageItem(5,46.81,36),
                            new PackageItem(6,48.77,79),
                            new PackageItem(7,81.80,45),
                            new PackageItem(8,19.36,79),
                            new PackageItem(9,6.76,64)
                        }
                    },
                    new List<PackageItem>()
                    {
                        new PackageItem(8,19.36,79),
                        new PackageItem(9,6.76,64)
                    }
                }
           };


        [Theory]
        [MemberData(nameof(TestCases))]
        public void SolvePackaging(PackageConfiguration testCase, List<PackageItem> expectedResult)
        {
            var solutionItems = _sut.Solve(testCase);

            solutionItems.Should().BeEquivalentTo(expectedResult);
        }

    }
}
