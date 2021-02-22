using System;

namespace Lab5
{
    public class ClientBuilder : Builder
    {
        private Client _client = new Client();

        public Builder AddAddress(string address)
        {
            _client.SetAddress(address);
            return this;
        }

        public Builder AddName(string name)
        {
            _client.SetName(name);
            return this;
        }

        public Builder AddPassport(int passport)
        {
            _client.SetPassport(passport);
            return this;
        }

        public Builder AddSurname(string surname)
        {
            _client.SetSurname(surname);
            return this;
        }

        public Builder Reset()
        {
            _client = new Client();
            return this;
        }

        public Client GetClient()
        {
            if (string.IsNullOrEmpty(_client.GetName()) || (string.IsNullOrEmpty(_client.GetSurname())))
                return _client;
            throw new ArgumentException("You can't add client without name and surname.");
        }
    }
}
