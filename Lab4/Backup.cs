using System;
using System.IO;
using System.Collections.Generic;
using ConsoleApplication1.Cleaner;

namespace ConsoleApplication1
{
    class Backup
    {
        private Dictionary<string, RestorePoint> _points = new Dictionary<string, RestorePoint>();
        private List<string> _files = new List<string>();
        private ICleaner _cleaner;

        public Backup(ICleaner cleaner, params string[] files)
        {
            if (_files.Count == 0)
                throw new Exception("The files count mustn't be 0");
            
            foreach (var file in files)
            {
                _files.Add(file);
            }
                
            _cleaner = cleaner;
            
        }

        public void AddFile(params string[] files)
        {
            foreach (var file in files)
            {
                if (!_files.Contains(file))
                {
                    _files.Add(file);
                }
            }
        }

        public void DeleteFile(params string[] files)
        {
            foreach (var file in files)
            {
                if (_files.Contains(file))
                {
                    _files.Remove(file);
                }
            }
        }

        public void AddFullPoint(string pathName)
        {
            List<FileInfo> files = new List<FileInfo>();
            foreach (var file in _files)
            {
                if (!File.Exists(file))
                    throw new Exception($"{file}: there isn't such file");
                files.Add(new FileInfo(file));
            }
            var fullPoint = new Full(pathName, files);
            _points.Add(pathName, fullPoint);
        }

        public void AddIncrementalPoint(string pathName, RestorePoint dep)
        {
            List<string> filesName = new List<string>();
            foreach (var file in dep.GetFiles())
            {
                if (!File.Exists(file.GetName()))
                    continue; //faila net
                if (file.GetSize() != File.ReadAllText(file.GetName()).Length || File.GetLastWriteTime(file.GetName()).Ticks != file.GetLastWriteTime())
                {
                    filesName.Add(file.GetName());
                }
            }

            List<FileInfo> files = new List<FileInfo>();
            foreach (var file in filesName)
            {
                if (!File.Exists(file))
                    throw new Exception($"{file}: there isn't such file");
                files.Add(new FileInfo(file));
            }
            var incPoint = new Incremental(pathName, files, dep);
            _points.Add(pathName, incPoint);
        }
        
        public Dictionary<string, RestorePoint> GetPoints()
        {
            return _points;
        }

        public void Clean()
        {
            List<string> toCopy = new List<string>();
            foreach (var point in _points)
            {
                if (_cleaner.IsWithin(point.Value))
                {
                    toCopy.Add(point.Key);
                }
                
            }
            Dictionary<string, RestorePoint> tmp = new Dictionary<string, RestorePoint>();
            foreach (var name in toCopy)
            {
                tmp.Add(name, _points[name]);
            }

            _points = tmp;
        }
    }
}