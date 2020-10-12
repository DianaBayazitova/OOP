using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1
{
    public class IniFile
    {
        private Dictionary<string, Dictionary<string, string>> data = new Dictionary<string, Dictionary<string, string>>();

        public void Load(string path)
        {
            try
            {
                using StreamReader sr = new StreamReader(path);
                string line;
                string current_section = "default";
                string current_parametr;
                string current_parametr_value;
                string section_pattern = @"^\[(\w)*_*(\w)*\]";
                string parametr_pattern = @"^(\w)+_*(\w)*";
                while ((line = sr.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line, section_pattern))
                    {
                        current_section = Regex.Match(line, section_pattern).Value;
                        data[current_section] = new Dictionary<string, string>();
                        continue;
                    }

                    if (Regex.IsMatch(line, parametr_pattern))
                    {
                        if (line.IndexOf('=') == -1)
                        {
                            continue;
                        }
                        current_parametr = Regex.Match(line, parametr_pattern).Value;
                        int start_of_comment = line.IndexOf(';');
                        if (start_of_comment == -1)
                        {
                            current_parametr_value = line.Substring(current_parametr.Length + 3);
                        }
                        else
                        {
                            current_parametr_value = line.Substring(current_parametr.Length + 3, start_of_comment - current_parametr.Length - 3);
                        }
                        data[current_section].Add(current_parametr, current_parametr_value);
                    }

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file could not be read");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid string");
            }
        }

        public T Get<T>(string section, string parametr, Func<string, T> func, T def)
        {
            try
            {
                foreach (var param in data[section])
                {
                    if (param.Key == parametr)
                    {
                        return func(param.Value);
                    }
                }
                throw (new Exception());
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key with this name doesn't exist");
            }
            catch (Exception)
            {
                Console.WriteLine("Parametr with this name doesn't exist");
            }

            return def;
        }

        public int GetInt(string section, string parametr)
        {
            return Get(section, parametr, Parametr.GetIntValue, -1);
        }

        public double GetDouble(string section, string parametr)
        {
            return Get(section, parametr, Parametr.GetDoubleValue, -1);
        }

        public string GetString(string section, string parametr)
        {
            return Get(section, parametr, Parametr.GetStringValue, null);
        }

        public void Print()
        {
            foreach (var pair in data)
            {
                Console.WriteLine(pair.Key);
                foreach (var param in data[pair.Key])
                    Console.WriteLine("{0} {1}", param.Key, param.Value);
            }
        }

    }
}
