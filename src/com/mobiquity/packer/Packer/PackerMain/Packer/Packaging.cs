using Packer.Core.Exceptions;
using System;

namespace Packer
{
    public static class Packaging
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="APIException">The method intersepts all exceptions thrown in the implementation services and </exception>
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
