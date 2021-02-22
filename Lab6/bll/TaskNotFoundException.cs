using System;

namespace lab6.bll
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(string message) : base(message)
        {
        }
    }
}
