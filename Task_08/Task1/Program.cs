using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Введите количество элементов:");
            while (!int.TryParse(Console.ReadLine(), out n)) Console.Write("Введено некорректное значение. Введите количество элементов:");
            double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите элемент под номером {0} :", i);
                while (!double.TryParse(Console.ReadLine(), out arr[i])) Console.Write("Введено некорректное значение. Введите элемент под номером {0} :", i);
            }
            Console.WriteLine("Сумма всех элементов: " + arr.SumArray());
            Console.ReadKey();
        }
    }
}
