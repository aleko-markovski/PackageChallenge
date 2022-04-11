using Packer.Models;

namespace Packer.Services
{
    public interface IValidation
    {
        public void Validate(PackageConfiguration packageConfiguration);
    }
}
