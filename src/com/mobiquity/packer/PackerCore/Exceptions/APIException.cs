using System;

namespace Packer.Core.Exceptions
{
    public class APIException : Exception
    {
        public APIException(string message, Exception exception) : base(message, exception) { }
    }
}
