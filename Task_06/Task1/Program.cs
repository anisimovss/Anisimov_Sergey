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
            Console.Write("Введите количество:");
            while (!int.TryParse(Console.ReadLine(), out n)) ;
            Cell circle = new Cell(1);
            CreateCircle(n, ref circle);
            Console.Write("Исходный круг:");
            for (int i = 1; i <= n; i++)
            {
                Console.Write(circle.Data + " ");
                circle = circle.Next;
            }
            Selection(ref circle);
            Console.WriteLine();
            Console.ReadKey();
        }

        public static void CreateCircle(int size, ref Cell head)
        {
            var circle = head;
            for (int i = 2; i <= size; i++)
            {
                circle.Next = new Cell(i);
                circle = circle.Next;
            }
            circle.Next = head;
        }

        public static void Selection(ref Cell head)
        {
            while (head.Next != head)
            {
                head.Next = head.Next.Next;
                head = head.Next;
                ShowCircle(head);
            }
        }

        public static void ShowCircle(Cell head)
        {
            Console.WriteLine();
            var start = head;
            Console.Write("Новый круг:");
            Console.Write(head.Data+ " ");
            head = head.Next;
            while(head != start)
            {
                Console.Write(head.Data + " ");
                head = head.Next;
            }
        }
    }
}
