using System;
using System.Collections.Generic;
using System.Linq;

namespace CoatOfArmsCore
{
    public static class StringExtensionMethods
    {
        public static bool NotEqual(this string s, string compare)
        {
            return (!string.Equals(s, compare, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
