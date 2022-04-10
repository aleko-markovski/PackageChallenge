using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constrains
{
    /// <summary>
    ///  
    /// </summary>
    public static class StringPatterns
    {
        /// <value>\u20AC is Unicode for the euro sign</value>
        public const string ItemPattern = @"\((?<index>\d+),(?<weight>\d+\.\d+),\u20AC(?<cost>\d+)\)";
        public const string LinePattern = @"\d+?\s+?\:(\s+?\(.+?\))+";
    }
}
