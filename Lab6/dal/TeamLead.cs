using System;
using System.Collections.Generic;

namespace lab6.dal
{
    public class TeamLead : IPerson
    {
        private static TeamLead _instance;
        public string Name { get; }
        public int Id { get; set; }
        public Leader Owner { get; set; } = null;
        private List<IPerson> _employees;


        private TeamLead(int id, string name)
        {
            Id = id;
            Name = name;
            _employees = new List<IPerson>();
        }

        public static TeamLead GetInstance()
        {
            return _instance ??= new TeamLead(1, "Diana");
        }

        public void AddEmployee(IPerson employee)
        {
            if (_employees.Contains(employee))
            {
                Console.WriteLine("Nothing to add");
                return;
            }

            _employees.Add(employee);
        }

        public void RemoveEmployee(IPerson employee)
        {
            if (_employees.Contains(employee))
            {
                _employees.Remove(employee);
                return;
            }

            Console.WriteLine("Nothing to remove");
        }
    }
}