using System;
using System.Collections.Generic;
using ConsoleApplication1.Cleaner;
using System.IO;
using System.Threading;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Cleaner.Cleaner cl = new Cleaner.Cleaner(true,new CountCleaner(1), new SizeCleaner(100));
            Backup backUp = new Backup(cl, "file1.txt", "file2.txt", "file3.txt");
            backUp.AddFullPoint("RP_A");
            backUp.AddIncrementalPoint("RP_B", backUp.GetPoints()["RP_A"]);
            backUp.AddIncrementalPoint("RP_C", backUp.GetPoints()["RP_B"]);
            Console.WriteLine(backUp.GetPoints().Count);

            backUp.Clean();
            Console.WriteLine(backUp.GetPoints().Count);
            foreach (var item in backUp.GetPoints())
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}