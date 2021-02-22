using System;

namespace Lab5
{
    class Program
    {
        static void Main()
        {
            Builder builder = new ClientBuilder();
            Client client = builder.AddName("Sergei").AddSurname("Ivanov").AddPassport(777762).GetClient();

            DebitAccount debit = new DebitAccount(client, 3.65, 2000, 365);
            DebitAccount debit1 = new DebitAccount(client, 3.65, 10000, 365);

            Console.WriteLine(debit1.GetAmount());
            Console.WriteLine(debit.GetAmount());

            debit1.DailyInterestAccrual();
            debit1.InterestAccrual();
            debit.Transfer(10000, debit1);

            Console.WriteLine(debit1.GetAmount());
            Console.WriteLine(debit.GetAmount());

            debit1.Withdrawal(10000);

            Console.WriteLine(debit1.GetAmount());
            Console.WriteLine(debit.GetAmount());

            debit.TransactionCancellation(0);

            Console.WriteLine(debit1.GetAmount());
            Console.WriteLine(debit.GetAmount());
        }
    }
}
