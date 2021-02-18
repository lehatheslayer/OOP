using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    class Incremental : RestorePoint
    {
        public Incremental(string name, List<FileInfo> files, RestorePoint dp)
        {
            Depend = dp;
            Type = 0;
            Time = DateTime.Now.Ticks;
            Name = name;
            Files = files;
            foreach (var file in files)
            {
                Size += file.GetSize();
            }
        }
        
    }
}