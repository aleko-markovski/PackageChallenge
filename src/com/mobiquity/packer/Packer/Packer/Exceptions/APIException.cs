using System;
using System.Collections.Generic;
using System.Text;

namespace Packer.Core.Exceptions
{
    public class APIException : Exception
    {
        public APIException(string message, Exception exception) : base(message, exception) { }
    }
}
