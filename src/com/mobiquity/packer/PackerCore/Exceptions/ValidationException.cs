using System;

namespace Packer.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        { }
    }
}
