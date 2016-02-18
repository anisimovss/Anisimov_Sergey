using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class ArrayHelper
    {
        public static int[] FindElem(this int[] arr)
        {
            List<int> l = new List<int>();
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > 0)
                {
                    l.Add(arr[i]);
                }
            return l.ToArray();
        }

        public delegate bool Function(int x);

        public static int[] FindElemWithDelegate(this int[] arr, Function func)
        {
            List<int> l = new List<int>();
            for (int i = 0; i < arr.Length; i++)
                if (func(arr[i]))
                {
                    l.Add(arr[i]);
                }
            return l.ToArray();
        }

        public static int[] FindElemWithLinq(this int[] arr)
        {
            var positiveNumber = from n in arr
                                 where n > 0
                                 select n;
            int[] result = positiveNumber.ToArray();
            return result;
        }
    }
}
