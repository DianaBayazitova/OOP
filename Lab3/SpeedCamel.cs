namespace lab3
{
    public class SpeedCamel : ILandTransport
    {
        public int Speed { get; } = 40;
        public string Name { get; } = "Speed Camel";
        public TransportType TransportType { get; } = TransportType.Land;
        public int TimeBeforeRest { get; } = 10;

        public double CalculateRestDuration(uint stopNumber)
        {
            if (stopNumber == 1) return 5;

            if (stopNumber == 2) return 6.5;

            return 8;
        }
    }
}