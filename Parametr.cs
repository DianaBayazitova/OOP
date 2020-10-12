using System;

namespace Lab1
{
    public static class Parametr
    {

        public static int GetIntValue(string value)
        {
            int res = -1;
            try
            {
                res = int.Parse(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("Parametr isn't int");
            }
            return res;
        }


        public static double GetDoubleValue(string value)
        {
            double res = -1;
            try
            {
                res = double.Parse(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("Parametr isn't double");
            }
            return res;
        }

        public static string GetStringValue(string value)
        {
            return value;
        }
    }
}