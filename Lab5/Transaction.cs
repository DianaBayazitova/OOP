namespace Lab5
{
    public class Transaction
    {
        private double _value;
        private Account _account;

        public Transaction(double value, Account account)
        {
            _value = value;
            _account = account;
        }

        public double GetValue()
        {
            return _value;
        }

        public Account GetAccount()
        {
            return _account;
        }
    }
}
