using Packer.ContentProvider;
using Packer.Core.Helper;
using Packer.Models;
using Packer.Services;
using Packer.Services.Implementation;
using Packer.Solution;
using Packer.Solution.Implementation;
using System.Collections.Generic;

namespace Packer
{
    /// <summary>
    /// Implemetation of the Packaging template
    /// </summary>
    public class PackageChallenge : PackagingTemplate
    {
        private readonly FileContentProvider _fileContentProvider;
        private readonly IFileOperations _fileOperationsService;
        private readonly IValidation _validationService;
        private readonly ISolutionAlgorithm _solverService;

        public PackageChallenge()
        {
            _fileOperationsService = new FileOperations();
            _fileContentProvider = new PackageConfigurationContentProvider(_fileOperationsService);
            _validationService = new ValidationService();
            _solverService = new PackagingSolutionAlgorithm();
        }

        public override List<PackageConfiguration> Extract(string filePath)
        {
            return _fileContentProvider.Load(filePath);
        }

        public override void Validate(PackageConfiguration packagConfiguration)
        {
            _validationService.Validate(packagConfiguration);
        }

        public override List<PackageItem> Solve(PackageConfiguration configuration)
        {
            return _solverService.Solve(configuration);
        }

        public override string Publish(List<PackageItem> items)
        {
            return StringifyItems.ToDelimitedString(items, ",", x => x.Index.ToString(), "-");
        }
    }
}
