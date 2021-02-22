namespace lab3
{
    public class Mortar : IAirTransport
    {
        public int Speed { get; } = 8;
        public string Name { get; } = "Mortar";
        public TransportType TransportType { get; } = TransportType.Air;

        public double CoefficientOfDistanceReduction(double distance)
        {
            return 0.94;
        }
    }
}