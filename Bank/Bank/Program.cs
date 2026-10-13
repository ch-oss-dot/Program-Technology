namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
         BankAccount account1 = new BankAccount("Yana", 1000000);
         BankAccount account2 = new BankAccount("Lena", 100);
            Console.WriteLine($"{account1.Owner} { account1.Balance} {account1.Number}");
            Console.WriteLine($"{account2.Owner} {account2.Balance} {account2.Number}");
            account1.MakeDeposite(12000, DateTime.UtcNow, ";)");
            Console.WriteLine($"Balance: {account1.Balance}");

            account1.MakeWithdrawal(123, DateTime.UtcNow, ":(");
            Console.WriteLine($"Balance: {account1.Balance}");
            Console.WriteLine(account1.GetAccountHistory());

            try
            {
                account2.MakeWithdrawal(10000, DateTime.UtcNow, "asdas");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            InterestEarningAccountcs interest = new InterestEarningAccountcs("Yana", 1000);
            interest.PerformMonthAndTransaction();
            Console.WriteLine(interest.GetAccountHistory());

            LineOfCreditAccount lineOfCredit = new LineOfCreditAccount("Yana", 0, 1000m);
            lineOfCredit.MakeWithdrawal(500m, DateTime.UtcNow, "credit");
            GiftCartAccount giftcart = new GiftCartAccount("Yana", 1000m,5000m);
            List<BankAccount> accounts = new List<BankAccount>();
            accounts.Add(account1);
            accounts.Add(interest);
            accounts.Add(lineOfCredit);
            accounts.Add(giftcart);
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine(account);//Console.WriteLine(account.ToString());
                account.PerformMonthAndTransaction();
                Console.WriteLine(account.GetAccountHistory());
            }

            lineOfCredit.MakeWithdrawal(600m, DateTime.UtcNow, "credit");
            Console.WriteLine(lineOfCredit.GetAccountHistory);
                
        }
    }
}
