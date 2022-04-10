using Packer.ContentProvider;
using Packer.Core.Helper;
using Packer.Models;
using Packer.Services;
using Packer.Services.Implementation;
using Packer.Solution;
using Packer.Solution.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Packer
{
    public class PackageChallenge : PackagingTemplate
    {
        readonly FileContentProvider _fileContentProvider;
        IFileOperations _fileOperationsService;
        readonly IValidation _validationService;
        readonly ISolutionAlgorithm _solverService;

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

        public override string Publish(List<PackageItem> items)
        {
            return StringifyItems.ToDelimitedString(items, ",", x => x.Index.ToString(), "-");
        }

        public override List<PackageItem> Solve(PackageConfiguration configuration)
        {
            return _solverService.Solve(configuration);
        }

        public override void Validate(PackageConfiguration packagConfiguration)
        {
            _validationService.Validate(packagConfiguration);
        }
    }
}
