using System.Collections.Generic;
using System.IO;

namespace lab4
{
    public class SeparateStorageAlgorithm : IAlgorithm
    {
        public List<FileInfo> Files { get; }

        public RestorePoint CreateFullRestorePoint(List<FileInfo> files)
        {
            foreach (var file in files)
            {
                file.Refresh();
                Files.Add(file);
            }

            return new RestorePoint(Files, true);

        }

        public RestorePoint CreateIncrementRestorePoint(List<FileInfo> files, RestorePoint previousPoint)
        {
           
            foreach (var file in files)
            {
                foreach (var previousPointFile in previousPoint.Files)
                {
                    if (file.FullName == previousPointFile.FullName &&
                        file.Length != previousPointFile.Length)
                    {
                        Files.Add(file);
                        files.Remove(file);
                        break;
                    }
                }
            }
            Files.AddRange(files);

            return new RestorePoint(Files, false);
        }
    }
}