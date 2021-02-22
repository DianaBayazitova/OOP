using System;

namespace lab3
{
    public class InvalidRaceException : Exception
    {
        public InvalidRaceException(string message) : base(message)
        {
        }
    }
}