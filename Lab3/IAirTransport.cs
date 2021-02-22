namespace lab3
{
    public interface IAirTransport : ITransport
    {
        double ITransport.GetTimeForRun(double distance)
        {
            distance *= CoefficientOfDistanceReduction(distance);

            return distance / Speed;
        }

        public double CoefficientOfDistanceReduction(double distance);
    }
}