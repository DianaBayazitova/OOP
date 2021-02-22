namespace Lab5
{
    public class DebitAccount : Account
    {
        public DebitAccount(Client client, double percent, double amount, int duration) : base(client, percent, 0, amount, duration, 0, 1000) { }
    }
}
