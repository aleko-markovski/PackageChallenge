using System;

namespace Packer.Exceptions
{
    public class ParsingException : Exception
    {
        public ParsingException(string message) : base(message){}
    }
}
