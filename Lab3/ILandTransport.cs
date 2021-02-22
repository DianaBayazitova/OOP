namespace lab3
{
    public interface ILandTransport : ITransport
    {
        public int TimeBeforeRest { get; }

        double ITransport.GetTimeForRun(double distance)
        {
            var minimumTime = distance / Speed;
            double time = 0;
            uint stopNumber = 0;
            while (distance > 0)
            {
                stopNumber += 1;
                if (minimumTime > TimeBeforeRest)
                {
                    time += TimeBeforeRest;
                    time += CalculateRestDuration(stopNumber);
                    distance -= Speed * TimeBeforeRest;
                }
                else
                {
                    time = minimumTime;
                    distance = 0;
                }
            }

            return time;
        }

        public double CalculateRestDuration(uint stopNumber);
    }
}