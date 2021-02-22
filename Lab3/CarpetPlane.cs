namespace lab3
{
    public class CarpetPlane : IAirTransport
    {
        public int Speed { get; } = 10;
        public string Name { get; } = "Carpet plane";
        public TransportType TransportType { get; } = TransportType.Air;

        public double CoefficientOfDistanceReduction(double distance)
        {
            if (distance < 1000) return 1;

            if (distance < 5000) return 0.97;

            return distance < 10_000 ? 0.9 : 0.95;
        }
    }
}