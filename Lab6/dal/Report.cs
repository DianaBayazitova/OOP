using System.Collections.Generic;

namespace lab6.dal
{
    public class Report
    {
        private readonly List<TaskInfo> _taskInfos;
     
        public int Id { get; }
        
        public ReportType Type { get; }

        public Report(int id, ReportType reportType)
        {
            Id = id;
            Type = reportType;
            _taskInfos = new List<TaskInfo>();
        }

        public void AddTaskInfo(TaskInfo taskInfo)
        {
            _taskInfos.Add(taskInfo);
        }
        
        
    }
}