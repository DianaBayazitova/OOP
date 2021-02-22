namespace lab6.dal
{
    public interface IPerson
    {
        public string Name { get; }
        public int Id { get; set; }
        public Leader Owner { get; set; }


    }
}