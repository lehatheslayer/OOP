using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    public class RestorePoint
    {
        protected long Time;
        protected string Name;
        protected int Type; //0 - incrimental, 1 - full
        protected List<FileInfo> Files;
        protected int Size;
        protected RestorePoint Depend = null;
        
        public new int GetType()
        {
            return Type;
        }
        
        public string GetName()
        {
            return Name;
        }
        
        public long GetTime()
        {
            return Time;
        }
        
        public List<FileInfo> GetFiles()
        {
            return Files;
        }
        
        public RestorePoint GetDepend()
        {
            return Depend;
        }

        public int GetSize()
        {
            return Size;
        }
    }
}