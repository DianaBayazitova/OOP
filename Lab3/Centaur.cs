namespace lab3
{
    public class Centaur : ILandTransport
    {
        public int Speed { get; } = 15;
        public string Name { get; } = "Centaur";
        public TransportType TransportType { get; } = TransportType.Land;
        public int TimeBeforeRest { get; } = 15;

        public double CalculateRestDuration(uint stopNumber)
        {
            return 2;
        }
    }
}