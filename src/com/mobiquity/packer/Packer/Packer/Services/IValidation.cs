using Packer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Packer.Services
{
    public interface IValidation
    {
        public void Validate(PackageConfiguration packageConfiguration);
    }
}
