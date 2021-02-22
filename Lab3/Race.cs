using System;
using System.Collections.Generic;

namespace lab3
{
    public class Race
    {
        private readonly List<ITransport> _transports = new List<ITransport>();
        public RaceType Type { get; set; }

        public void AddTransport(ITransport transport)
        {
            if (transport.TransportType == TransportType.Land && Type == RaceType.OnlyAirTransport ||
                transport.TransportType == TransportType.Air && Type == RaceType.OnlyLandTransport)
                throw new InvalidTransportTypeException("Transport of this type is not allowed in this type of race");

            _transports.Add(transport);
        }

        public void Run(double distance)
        {
            if (_transports.Count == 0)
            {
                throw new InvalidRaceException("Can't run without transport");
                ;
            }

            double minTime = int.MaxValue;
            ITransport winner = null;
            foreach (var transport in _transports)
            {
                var currentTime = transport.GetTimeForRun(distance);
                if (currentTime < minTime)
                {
                    minTime = currentTime;
                    winner = transport;
                }
            }

            Console.Out.WriteLine("And the winner is " + winner.Name);
        }
    }
}