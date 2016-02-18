using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            long[] findTime = new long[10];
            long[] findDelegateTime = new long[10];
            long[] findAnonymousTime = new long[10];
            long[] findLinqTime = new long[10];
            long[] findLambdaTime = new long[10];
            Random rdm = new Random();
            int[] arr = new int[100];
            for (int i = 0; i < arr.Length; i++) arr[i] = rdm.Next(-100, 100);
            time.Start();
            time.Stop();

            for (int i = 0; i < 10; i++)
            {
                time.Restart();
                arr.FindElem();
                time.Stop();
                findTime[i] = time.ElapsedTicks;
            }
            Array.Sort(findTime);

            for (int i = 0; i < 10; i++)
            {
                time.Restart();
                arr.FindElemWithDelegate(CompareNumber);
                time.Stop();
                findDelegateTime[i] = time.ElapsedTicks;
            }
            Array.Sort(findDelegateTime);

            for (int i = 0; i < 10; i++)
            {
                time.Restart();
                arr.FindElemWithDelegate(delegate (int x)
                {
                    if (x > 0) return true;
                    else return false;
                });
                time.Stop();
                findAnonymousTime[i] = time.ElapsedTicks;
            }
            Array.Sort(findAnonymousTime);

            for (int i = 0; i < 10; i++)
            {
                time.Restart();
                arr.FindElemWithDelegate((x) => x > 0);
                time.Stop();
                findLambdaTime[i] = time.ElapsedTicks;
            }
            Array.Sort(findLambdaTime);

            for (int i = 0; i < 10; i++)
            {
                time.Restart();
                arr.FindElemWithLinq();
                time.Stop();
                findLinqTime[i] = time.ElapsedTicks;
            }
            Array.Sort(findLinqTime);

            Console.WriteLine("Затраченное время на поиск всех положительных элементов в массиве напрямую:" + findTime[5]);
            Console.WriteLine("Затраченное время на поиск всех положительных элементов в массиве через делегат:"+ findDelegateTime[5]);
            Console.WriteLine("Затраченное время на поиск всех положительных элементов в массиве через делегат в виде анонимного метода:"+ findAnonymousTime[5]);
            Console.WriteLine("Затраченное время на поиск всех положительных элементов в массиве через делегат в виде лямбда-выражения:"+ findLambdaTime[5]);
            Console.WriteLine("Затраченное время на поиск всех положительных элементов в массиве через LINQ-выражения:"+ findLinqTime[5]);
        }

        static bool CompareNumber(int x)
        {
            if (x > 0) return true;
            else return false;
        }
    }
}
