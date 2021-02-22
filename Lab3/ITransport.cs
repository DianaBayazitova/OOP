namespace lab3
{
    public interface ITransport
    {
        public int Speed { get; }
        public string Name { get; }
        public TransportType TransportType { get; }
        public double GetTimeForRun(double distance);
    }
}