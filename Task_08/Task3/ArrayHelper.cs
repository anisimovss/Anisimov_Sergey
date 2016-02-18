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
            int[] result = new int[arr.Length];
            int k = 0;
            for (int i = 0; i < 0; i++)
                if (arr[i] > 0)
                {
                    result[k] = arr[i];
                    k++;
                }
            return result;
        }

        public delegate bool Function(int x);

        static Function FindAnonymous = delegate (int x)
        {
            if (x > 0) return true;
            else return false;
        };

        public static int[] FindElemWithDelegate(this int[] arr, Function func)
        {
            int[] result = new int[arr.Length];
            int k = 0;
            for (int i = 0; i < 0; i++)
                if (func(arr[i]))
                {
                    result[k] = arr[i];
                    k++;
                }
            return result;
        }

        public static int[] FindElemWithAnonymous(this int[] arr)
        {
            int[] result = new int[arr.Length];
            int k = 0;
            for (int i = 0; i < 0; i++)
                if (FindAnonymous(arr[i]))
                {
                    result[k] = arr[i];
                    k++;
                }
            return result;
        }




    }
}
