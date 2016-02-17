using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class ArrayHelper
    {
        public static double SumArray(this double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++) sum += arr[i];
            return sum;
        }
    }
}
