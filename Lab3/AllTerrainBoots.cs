namespace lab3
{
    public class AllTerrainBoots : ILandTransport
    {
        public int Speed { get; } = 6;
        public string Name { get; } = "All-terrain boots";
        public TransportType TransportType { get; } = TransportType.Land;
        public int TimeBeforeRest { get; } = 60;

        public double CalculateRestDuration(uint stopNumber)
        {
            if (stopNumber == 1) return 10;

            return 5;
        }
    }
}