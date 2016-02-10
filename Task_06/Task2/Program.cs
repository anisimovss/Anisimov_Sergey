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
            Console.Write("Введите строку:");
            string str = Console.ReadLine();
            List<string> words = new List<string>();
            int i = 0;
            int iStart = 0;
            int count = 0;
            while (i < str.Length)
            {
                if ((str[i] != ' ') && (str[i] != '.'))
                {
                    count++;
                    if (i == str.Length - 1) words.Add(str.Substring(iStart, count));
                    i++;
                }
                else
                {
                    if ((i != 0) && (str[i - 1] != ' ') && (str[i - 1] != '.'))
                    {
                        words.Add(str.Substring(iStart, count));
                        count = 0;
                    }
                    i++;
                    iStart = i;
                }
            }
            count = 0;
            for (i = 0; i < words.Count; i++)
            {
                if (words[i] != null)
                {
                    for (int j = i; j < words.Count; j++)
                    {
                        if ((words[j] != null) && (words[i].Equals(words[j], StringComparison.InvariantCultureIgnoreCase)))
                        {
                            count++;
                            if (i!=j) words[j] = null;
                        }
                    }
                    Console.WriteLine("Слово: {0} встречается {1} раз", words[i], count);
                }
                count = 0;
            }
        }
    }
}
