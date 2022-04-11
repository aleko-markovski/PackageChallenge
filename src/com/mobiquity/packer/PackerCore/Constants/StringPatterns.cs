using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constrains
{
    public static class StringPatterns
    {
        
        /// <value>\u20AC is Unicode for the euro sign</value>
        /// item values: weight, cost, index can be extracted in match group
        public const string ItemPattern = @"\((?<index>\d+),(?<weight>\d+\.\d+),\u20AC(?<cost>\d+)\)";
        public const string LinePattern = @"\d+?\s+?\:(\s+?\(.+?\))+";
    }
}
