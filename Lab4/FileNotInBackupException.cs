using System;

namespace lab4
{
    public class FileNotInBackupException : Exception
    {
        public FileNotInBackupException(string message) : base(message)
        {
        }
    }
}