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
            Console.Write("Введите количество строк:" );
            while (!int.TryParse(Console.ReadLine(), out n)) Console.Write("Введено некорректное значение. Введите количество строк:");
            string[] str = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите строку под номером {0} :", i);
                str[i] = Console.ReadLine();
            }
            Function func = new Function(CompareString);
            str = SortString(str, func);
            foreach (string elem in str) Console.WriteLine(elem);
            Console.ReadKey();
        }

        delegate bool Function(string s1, string s2);

        static bool CompareString(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                return true;
            }
            else if (str1.Length == str2.Length)
            {
                for (int k = 0; k < str1.Length; k++)
                {
                    if (str1[k] > str2[k])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static string[] SortString(string[] str, Function f)
        {
            string tmp;
            for (int i = 0; i < str.Length - 1; i++)
            {
                for (int j = 0; j < str.Length - 1 - i; j++)
                {
                    if (f(str[j], str[j + 1]))
                    {
                        tmp = str[j];
                        str[j] = str[j + 1];
                        str[j + 1] = tmp;

                    }
                }
            }
            return str;
        }
    }
}
