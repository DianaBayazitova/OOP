namespace lab3
{
    public class Broom : IAirTransport
    {
        public int Speed { get; } = 20;
        public string Name { get; } = "Broom";
        public TransportType TransportType { get; } = TransportType.Air;

        public double CoefficientOfDistanceReduction(double distance)
        {
            return 1 - distance / 100_000;
        }
    }
}