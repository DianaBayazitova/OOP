using System;

namespace lab6.dal
{
    public class TaskInfo
    {
        public DateTime CreationTime { get; }
        public TaskInfoType Type { get; }

        public Task Task { get; }

        public TaskInfo(TaskInfoType type, Task task)
        {
            CreationTime = DateTime.Now;
            Type = type;
            Task = task;
        }
    }
}