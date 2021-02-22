using System;

namespace lab3
{
    public class Program
    {
        private static void Main()
        {
            var race = new Race();
            race.Type = RaceType.AnyTransportType;
            try
            {
                race.AddTransport(new Broom());
                race.AddTransport(new BactrianCamel());
                race.AddTransport(new Centaur());
                race.Run(10);
            }
            catch (InvalidTransportTypeException exception)
            {
                Console.WriteLine("Can't add transport to race:");
                Console.WriteLine(exception.Message);
            }
            catch (InvalidRaceException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}