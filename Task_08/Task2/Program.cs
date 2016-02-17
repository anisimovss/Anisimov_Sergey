using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            if (str.IsPositiveNumber()) Console.WriteLine("Эта строка является положительным целым числом");
            else Console.WriteLine("Эта строка не является положительным целым числом");
        }
    }
}
