using System;

namespace Lab5
{
    public class CreditAccount : Account
    {
        public CreditAccount(Client client, int commission, double amount, int duration, int limit) : base(client, 0, commission, amount, duration, -limit, 20000){
        }

        public override bool Withdrawal(double value) 
        {
            if (_amount > _limit)
            {
                base.Withdrawal(value);
                return true;
            }
            throw new ArgumentException("Limit exceeded.");
        }

        public override void Transfer(double value, Account account)
        {
            if(_amount > _limit)
                base.Transfer(value, account);
            else
                throw new ArgumentException("Limit exceeded.");
        }
    }
}
