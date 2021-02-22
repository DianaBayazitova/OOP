using System;
using System.Collections.Generic;
using lab6.dal;

namespace lab6.bll
{
    public class ReportSystem
    {
        private static ReportSystem _instance;
        public List<Task> Tasks { get; }
        public List<IPerson> Employees { get; }

        private ReportSystem()
        {
            Tasks = new List<Task>();
            Employees = new List<IPerson>();
        }

        public static ReportSystem GetInstance()
        {
            return _instance ??= new ReportSystem();
        }

        public void AddEmployee(IPerson employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployee(IPerson employee)
        {
            Employees.Remove(employee);
        }

        public void AssignNewLeaderToEmployee(IPerson employee, IPerson leader)
        {
            Employees.Find(emp => emp.Id == employee.Id).Owner = (Leader) leader;
        }

        public Task FindTask(int id)
        {
            foreach (var task in Tasks)
            {
                if (task.Id == id)
                    return task;
            }

            throw new TaskNotFoundException("There is no task with such id");
        }

        public Task FindTask(DateTime creationDate)
        {
            foreach (var task in Tasks)
            {
                if (task.CreationDate == creationDate)
                    return task;
            }

            throw new TaskNotFoundException("There is no task with such creation date");
        }

        public List<Task> FindTask(IPerson employee)
        {
            List<Task> ans = new List<Task>();
            foreach (var task in Tasks)
            {
                if (task.Employee == employee)
                    ans.Add(task);
            }

            if (ans.Count != 0)
            {
                return ans;
            }

            throw new TaskNotFoundException("There are no tasks with such employee");
        }

        public List<Task> FindChangedTask()
        {
            List<Task> ans = new List<Task>();
            foreach (var task in Tasks)
            {
                if (task.Comments.Count != 0)
                    ans.Add(task);
            }

            if (ans.Count != 0)
            {
                return ans;
            }

            throw new TaskNotFoundException("There are no tasks with changes");
        }

        public Report CreateDailyReport(int id, List<TaskInfo> taskInfos)
        {
            Report report = new Report(id, ReportType.Daily);
            foreach (var taskInfo in taskInfos)
            {
                report.AddTaskInfo(taskInfo);
            }

            return report;
        }

        public Report CreateSprintReport(int id, List<TaskInfo> taskInfos)
        {
            Report report = new Report(id, ReportType.Sprint);
            foreach (var taskInfo in taskInfos)
            {
                report.AddTaskInfo(taskInfo);
            }

            return report;
        }
    }
}
