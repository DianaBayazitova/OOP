namespace lab6.dal
{
    public class Employee : IPerson
    {
        public int Id { get; set; }
        public string Name { get; }
        public Leader Owner { get; set; }

        public Employee(string name, Leader leader)
        {
            Name = name;
            Owner = leader;
        }
    }
}