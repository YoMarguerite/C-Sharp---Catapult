using Cast.Package.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.Package.Extensions
{
    public static class StringExtension
    {
        public static int ToLife(this string str)
        {
            str = str.Substring(19, str.Length - 22);

            int result;

            if (!((Int32.TryParse(str, out result)) && (result < 100)))
            {
                throw new FormatLifeException(str);
            }

            return result;
        }
    }
}
