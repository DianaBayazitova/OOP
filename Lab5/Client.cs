using System;

namespace Lab5
{
    public class Client
    {
        private string _name;
        private string _surname;
        private string _address;
        private int _passport;

        public void SetName (string name)
        {
            _name = name;
        }

        public void SetSurname(string surname)
        {
            _surname = surname;
        }

        public void SetAddress(string address)
        {
            _address = address;
        }

        public void SetPassport(int passport)
        {
            _passport = passport;
        }

        public int GetPassport()
        {
            return _passport;
        }

        public string GetAddress()
        {
            return _address;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public void Show()
        {
            Console.WriteLine("Name: {0}", _name);
            Console.WriteLine("Surname: {0}", _surname);
            Console.WriteLine("Address: {0}", _address);
            Console.WriteLine("Passport number: {0}", _passport);
        }
    }
}
