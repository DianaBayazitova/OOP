using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo filePath1 = new FileInfo (@"C:\Users\Diana\test1.txt");
            FileInfo filePath2 = new FileInfo (@"C:\Users\Diana\test2.txt");
            FileInfo filePath3 = new FileInfo (@"C:\Users\Diana\test3.txt");
            FileInfo storagePath = new FileInfo (@"C:\Users\Diana\backup");
            FileInfo archivePath = new FileInfo (@"C:\Users\Diana\backup.zip");
            List<FileInfo> fileInfos = new List<FileInfo>();
            fileInfos.Add(filePath1);
            fileInfos.Add(filePath2);
            fileInfos.Add(filePath3);
            fileInfos.Add(storagePath);
            fileInfos.Add(archivePath);
            Backup backup = new Backup(5, fileInfos, new SeparateStorageAlgorithm());
            backup.CreateFullRestorePoint();

        }
    }
}