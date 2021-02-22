namespace lab3
{
    public class BactrianCamel : ILandTransport
    {
        public int Speed { get; } = 10;
        public string Name { get; } = "Bactrian Camel";
        public TransportType TransportType { get; } = TransportType.Land;

        public int TimeBeforeRest { get; } = 30;

        public double CalculateRestDuration(uint stopNumber)
        {
            if (stopNumber == 1) return 5;

            return 8;
        }
    }
}