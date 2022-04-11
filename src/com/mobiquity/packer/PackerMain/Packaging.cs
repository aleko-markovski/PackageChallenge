using Packer.Core.Exceptions;
using System;

namespace Packer
{
    public class Packaging
    {
        /// <summary>
        /// Method that reads content from file and returns solution to each row (problem). 
        /// </summary>
        /// <param name="fileName">Path to file. Supports relative and absolute path</param>
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
