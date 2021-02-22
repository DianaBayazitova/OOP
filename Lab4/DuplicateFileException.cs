using System;

namespace lab4
{
    public class DuplicateFileException : Exception
    {
        public DuplicateFileException(string message) : base(message)
        {
        }
    }
}