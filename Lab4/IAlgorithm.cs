using System.Collections.Generic;
using System.IO;

namespace lab4
{
    public interface IAlgorithm
    {
        public RestorePoint CreateFullRestorePoint(List<FileInfo> files);
        public RestorePoint CreateIncrementRestorePoint(List<FileInfo> files, RestorePoint previousPoint);
    }
}