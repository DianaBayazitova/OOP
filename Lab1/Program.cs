using System;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main()
        {
            IniFile file = new IniFile();
            file.Load("test.ini");
            file.Print();
            //Console.WriteLine(file.GetInt("[COMMON]", "StatisterTimeMs"));
            //Console.WriteLine(file.GetDouble("[ADC_DEV]", "BufferLenSeconds"));
            Console.WriteLine(file.GetString("[ADC_DEV]", "Driver"));
        }
    }
}
