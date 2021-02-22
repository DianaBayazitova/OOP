using System;

namespace lab3
{
    public class InvalidTransportTypeException : Exception
    {
        public InvalidTransportTypeException(string message) : base(message)
        {
        }
    }
}