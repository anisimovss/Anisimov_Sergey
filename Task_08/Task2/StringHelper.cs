using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class StringHelper
    {
        public static bool IsPositiveNumber(this string str)
        {
            if (Convert.ToByte('-') == str[0]) return false;
            else {
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (((Convert.ToByte(str[i]) - Convert.ToByte('0')) > 9) || ((Convert.ToByte(str[i]) - Convert.ToByte('0')) < 0)) return false;
                }
                return true;
            }
        }
    }
}
