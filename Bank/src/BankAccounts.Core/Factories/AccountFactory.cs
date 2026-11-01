
using BankAccounts.Core.AccountNumbers;
using BankAccounts.Core.Accounts;
using BankAccounts.Core.MonthEnd;
using BankAccounts.Core.Time;
using BankAccounts.Core.Withdrawals;

namespace BankAccounts.Core.Factories;

public class AccountFactory
{
    private readonly IClock _clock;
    private readonly IAccountNumberGenerator _numbers;
    public AccountFactory(IClock clock, IAccountNumberGenerator numbers)
    {
        _clock = clock;
        _numbers = numbers;
    }

    public BankAccount CreateInterestEarning(string owner, decimal initialbalance)
        => new BankAccount(_clock, owner, initialbalance, 0m, _numbers, new StrictWithdrawalpolicy(), new IMonthEndRule[] { new InterestOnPositiveBalanceRule(0.2m, 500m) });
}
