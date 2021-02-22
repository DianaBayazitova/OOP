using System;
using System.Collections.Generic;
using lab6.bll;

namespace lab6.dal
{
    public class Leader : IPerson
    {
        public int Id { get; set; }
        public Leader Owner { get; set; }
        public string Name { get; }

        private List<IPerson> _employees;

        public Leader(string name)
        {
            Name = name;
            _employees = new List<IPerson>();
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