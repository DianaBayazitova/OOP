using System;

namespace Lab5
{
    public class Deposit : Account
    {
        public Deposit(Client client, double amount, int duration) : base(client, 0, 0, amount, duration, 0, 20000)
        {
            if (amount < 50000)
            {
                _percent = 0.03;
            }
            else if (amount < 100000)
            {
                _percent = 0.035;
            }
            else
            {
                _percent = 0.04;
            }
        }

        public override bool Withdrawal(double value)
        {
            if (_duration == 0)
            {
                base.Withdrawal(value);
                return true;
            }
            throw new ArgumentException("You can't withdraw money while duration.");
        }

        public override void Transfer(double value, Account account)
        {
            if (_duration == 0)
                base.Transfer(value, account);
            else
                throw new ArgumentException("You can't transfer money while duration.");
        }
    }
}
