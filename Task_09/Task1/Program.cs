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
            DirectoryInfo dir = Directory.CreateDirectory(pathTmpDirectory);
            Console.WriteLine("start");
            Change(pathFileDirectory);
            Console.ReadLine();
        }

        static void Change(string path)
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
