using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    class Full : RestorePoint
    {
        public Full(string name, List<FileInfo> files)
        {
            Type = 1;
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