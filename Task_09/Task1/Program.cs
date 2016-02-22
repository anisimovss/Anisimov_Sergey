using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static string pathFileDirectory = @"C:\....\fileplace";
        static string pathTmpDirectory = @"C:\....\fileplace\tmplocal";

        static void Main(string[] args)
        {
            //задание выполнил не правильно, не сразу увиедел что нужно сохранять папку.
            bool flag = true;
            int n;
            DirectoryInfo dir = Directory.CreateDirectory(pathFileDirectory);
            DirectoryInfo dirTmp = Directory.CreateDirectory(pathTmpDirectory);
            while (flag)
            {
                Console.WriteLine("Выберите режим(номер):");
                Console.WriteLine("1-Режим наблюдения");
                Console.WriteLine("2-Режим отката изменений");
                Console.WriteLine("3-Выход");
                while (!int.TryParse(Console.ReadLine(), out n)) Console.Write("Введено некорректное значение.");
                if (n == 1)
                {
                    Console.WriteLine("Режим наблюдения");
                    Subscribe(pathFileDirectory);
                    Console.ReadLine();
                }
                else if (n == 2)
                {
                    Console.WriteLine("Режим отката изменений");
                    Show(dirTmp);
                    Console.WriteLine("Введите дату и имя файла:");
                    string str = Console.ReadLine();
                    int i = str.Length - 1;
                    while (str[i] != ' ') i--;
                    File.Copy(pathTmpDirectory + "\\" + str, pathFileDirectory + "\\" + str.Substring(i + 1, str.Length - i - 1), true);
                }
                else if (n == 3) flag = false;
            }
        }

        static void Show(DirectoryInfo dir)
        {
            FileInfo[] files = dir.GetFiles();
            if (files.Length != 0)
            {
                Console.WriteLine("Найдено файлов: {0}", files.Length);
                foreach (FileInfo item in files) Console.WriteLine("File: {0} ", item.Name);
            }
        }

        static void Subscribe(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(path, "*.txt");
            watcher.Created += new FileSystemEventHandler(watcher_Created);
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            watcher.Renamed += watcher_Renamed;
            watcher.EnableRaisingEvents = true;
        }

        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл {0} был изменен", e.Name);
            File.Copy(pathFileDirectory + "\\" + e.Name, pathTmpDirectory + "\\"+ DateTime.Now.ToString("yyyy-MM-dd hh.mm.ss ") + e.Name, true);
        }

        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл {0} был создан", e.Name);
        }

        static void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("Имя файла {0} было изменено", e.Name);
            File.Copy(pathFileDirectory + "\\" + e.Name, pathTmpDirectory + "\\" + DateTime.Now.ToString("yyyy-MM-dd hh.mm.ss ") + e.Name, true);
        }
    }
}
