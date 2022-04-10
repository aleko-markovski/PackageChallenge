using Packer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Packer.Core.Helper
{
    public static class StringifyItems
    {
        public static string ToDelimitedString<T>(this List<T> source, string delimiter, Func<T, string> func, string defaultOutput)
        {
            if (source == null || !source.Any()) return defaultOutput;
            return String.Join(delimiter, source.Select(func));
        }

    }
}
