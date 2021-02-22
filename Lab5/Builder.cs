using System;

namespace Lab5
{
    public interface Builder
    {
        Builder Reset();
        Builder AddName(string name);
        Builder AddSurname(string surname);
        Builder AddAddress(string address);
        Builder AddPassport(int passport);
        Client GetClient();
    }
}
