using BankAccounts.Core.Accounts;

//Ежемесячное пополнение (для подарочной карты)
namespace BankAccounts.Core.MonthEnd
{
    public class MonthlyDepositeRule : IMonthEndRule
    {
        private readonly decimal _amount;
        public MonthlyDepositeRule(decimal amount)
        {
            _amount = amount;
        }

        public void Apply(IAccountOperations account, DateTime asOf)
        {
            if (_amount != 0)
                account.Deposit(_amount, asOf, "Add monthly deposit");
        }
    }
}
