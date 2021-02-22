using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab4
{
    public class Backup
    {
        private IAlgorithm Algorithm { get; }
        private List<FileInfo> Files { get; }
        private List<RestorePoint> RestorePoints { get; }

        public bool IsBySizeDeletable { get; } = false;
        public bool IsByDateDeletable { get; } = false;
        public bool IsByAmountDeletable { get; } = false;
        public bool CheckAllLimits { get; } = true;

        private int MaxAmount { get; } = int.MaxValue;
        private DateTime MaxDate { get; } = DateTime.MaxValue;
        private int MaxSize { get; } = int.MaxValue;


        private int id;
        private long _currentSize;
        private DateTime CreationTime { get; }


        public Backup(int id, List<FileInfo> files, IAlgorithm algorithm)
        {
            Files = files;
            this.id = id;
            CreationTime = DateTime.Now;
            Algorithm = algorithm;
            RestorePoints = new List<RestorePoint>();
        }


        public void AddFile(string filePath)
        {
            foreach (var file in Files)
            {
                if (file.Name == filePath)
                {
                    throw new DuplicateFileException("File with this name is already in backup");
                }
            }

            Files.Add(new FileInfo(filePath));
        }

        public void RemoveFile(string filePath)
        {
            foreach (var file in Files)
            {
                if (file.Name == filePath)
                {
                    Files.Remove(file);
                    return;
                }
            }

            throw new FileNotInBackupException("File with this name is already in backup");
        }

        public void ShowFiles()
        {
            if (Files.Count == 0)
            {
                Console.WriteLine("Backup is empty, nothing to show");
            }
            else
            {
                Console.WriteLine("Files in this backup:");
                foreach (var file in Files)
                {
                    Console.WriteLine(file.Name);
                }
            }
        }

        public void CreateFullRestorePoint()
        {
            RestorePoint newRestorePoint = Algorithm.CreateFullRestorePoint(Files);
            RestorePoints.Add(newRestorePoint);
            _currentSize += newRestorePoint.PointSize;
            AdaptToLimits();
        }

        public void CreateIncrementRestorePoint()
        {
            RestorePoint newRestorePoint = Algorithm.CreateIncrementRestorePoint(Files, RestorePoints.Last());
            RestorePoints.Add(newRestorePoint);
            _currentSize += newRestorePoint.PointSize;
            AdaptToLimits();
        }

        private void AdaptToLimits()
        {
            if (!CheckAllLimits)
            {
                List<RestorePoint> listToDelete = new List<RestorePoint>();
                if (IsByAmountDeletable)
                {
                    listToDelete.AddRange(CheckAmount());
                }

                if (IsByDateDeletable)
                {
                    listToDelete.AddRange(CheckDate());
                }

                if (IsBySizeDeletable)
                {
                    listToDelete.AddRange(CheckSize());
                }

                foreach (var point in listToDelete)
                {
                    RestorePoints.Remove(point);
                }
            }
            else
            {
                List<RestorePoint> listToDelete = new List<RestorePoint>();
                if (IsByAmountDeletable)
                {
                    listToDelete.AddRange(CheckAmount());
                }

                if (IsByDateDeletable)
                {
                    List<RestorePoint> listToDeleteByDate = CheckDate();
                    List<RestorePoint> listToDeleteByAmount = new List<RestorePoint>(listToDelete);
                    listToDelete.Clear();
                    foreach (var point in listToDeleteByAmount)
                    {
                        foreach (var anotherPoint in listToDeleteByDate)
                        {
                            if (point == anotherPoint)
                            {
                                listToDelete.Add(point);
                                break;
                            }
                        }
                    }
                }

                if (IsBySizeDeletable)
                {
                    List<RestorePoint> listToDeleteBySize = CheckSize();
                    List<RestorePoint> listToDeleteByAmountAndDate = new List<RestorePoint>(listToDelete);
                    listToDelete.Clear();
                    foreach (var point in listToDeleteByAmountAndDate)
                    {
                        foreach (var anotherPoint in listToDeleteBySize)
                        {
                            if (point == anotherPoint)
                            {
                                listToDelete.Add(point);
                                break;
                            }
                        }
                    }
                }

                foreach (var point in listToDelete)
                {
                    RestorePoints.Remove(point);
                }
            }
        }

        private List<RestorePoint> CheckAmount()
        {
            List<RestorePoint> pointsToRemove = new List<RestorePoint>();
            int i = 0;
            while (RestorePoints.Count > MaxAmount)
            {
                if (RestorePoints[i].IsFull)
                {
                    i++;
                }
                else
                {
                    pointsToRemove.Add(RestorePoints[i]);
                }

                if (i == RestorePoints.Count)
                {
                    break;
                }
            }

            return pointsToRemove;
        }

        private List<RestorePoint> CheckDate()
        {
            List<RestorePoint> pointsToRemove = new List<RestorePoint>();
            foreach (var restorePoint in RestorePoints)
            {
                if (restorePoint.CreationTime < MaxDate && !restorePoint.IsFull)
                {
                    pointsToRemove.Add(restorePoint);
                }
            }

            return pointsToRemove;
        }

        private List<RestorePoint> CheckSize()
        {
            List<RestorePoint> pointsToRemove = new List<RestorePoint>();
            int i = 0;
            while (_currentSize > MaxSize)
            {
                if (RestorePoints[i].IsFull)
                {
                    i++;
                }
                else
                {
                    _currentSize -= RestorePoints[i].PointSize;
                    pointsToRemove.Add(RestorePoints[i]);
                }

                if (i == RestorePoints.Count)
                {
                    break;
                }
            }

            return pointsToRemove;
        }
    }
}