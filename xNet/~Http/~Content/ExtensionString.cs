using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xNet
{
    static class ExtensionString
    {
        public static string FindValue(this string tx, string key, string lastchar)
        {
            int first = tx.IndexOf(key) + key.Length;
            int last = tx.IndexOf(lastchar, first);
            if (last == -1)
                last = tx.Length;
            string value = tx.Substring(first, last - first);
            return value;
        }
    }
}
