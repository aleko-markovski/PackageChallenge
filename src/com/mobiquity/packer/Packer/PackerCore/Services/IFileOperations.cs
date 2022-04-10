using System;
using System.Collections.Generic;
using System.Text;

namespace Packer.ContentProvider
{
    /// <summary>
    /// Extracted file operations as a service for better testability
    /// </summary>
    public interface IFileOperations
    {
        public string[] ReadAllLines(string path);
    }
}
