using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab4
{
    public class RestorePoint
    {
        public bool IsFull { get; }
        public readonly List<FileInfo> Files = new List<FileInfo>();
        public long PointSize { get; }
        public DateTime CreationTime { get; }

        public RestorePoint(List<FileInfo> files, bool isFull)
        {
            Files = files;
            IsFull = isFull;
            CreationTime = DateTime.Now;

            PointSize = 0;
            foreach (var file in Files)
            {
                PointSize += file.Length;
            }
        }
    }
}