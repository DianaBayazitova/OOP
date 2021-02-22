using System;
using System.Collections.Generic;
using lab6.bll;

namespace lab6.dal
{
    public class Task
    {
        public string Name { get; }
        public int Id { get; }
        public string Description { get; }
        public TaskStatus Status { get; set; }
        public List<string> Comments { get; }
        public Employee Employee { get; set; }
        public DateTime CreationDate { get; }
        public DateTime LastChangeDate { get; set; }

        public Task(string name, string description, int id)
        {
            Name = name;
            Description = description;
            Comments = new List<string>();
            Id = id;
            CreationDate = DateTime.Now;
        }
    }
}