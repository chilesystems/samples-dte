using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEAPI_Demo.Impresion.Core.Helpers
{
    public static class StringHelper
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            if (value.Length > maxLength)
                Console.WriteLine(string.Format("Truncate performed: {0} to {1}", value, value.Substring(0, maxLength)));
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string CenterTo(this string value, int lenght)
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value)) return value;
            if (value.Length > lenght) return value;
            return value.PadLeft(value.Length + ((lenght - value.Length) / 2), ' ');
        }
    }
}
