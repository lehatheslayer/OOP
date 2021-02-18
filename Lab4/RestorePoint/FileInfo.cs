using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    public class FileInfo
    {
        private readonly int _size;
        private readonly string _name;
        private readonly long _lastWriteTime;

        public FileInfo(string name)
        {
            _name = name;
            _size = File.ReadAllText(name).Length;
            _lastWriteTime = File.GetLastWriteTime(name).Ticks;
        }

        public int GetSize()
        {
            return _size;
        }

        public string GetName()
        {
            return _name;
        }

        public long GetLastWriteTime()
        {
            return _lastWriteTime;
        }

    }
}