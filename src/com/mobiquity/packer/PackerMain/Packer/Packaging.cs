using Packer.Core.Exceptions;
using System;

namespace Packer
{
    public static class Packaging
    {
        public static string Pack(string fileName)
        {
            try
            {
                var packer = new PackageChallenge();
                return packer.Execute(fileName);
            }
            catch (Exception ex)
            {
                throw new APIException(ex.Message, ex.InnerException);
            }
        }

    }
}
