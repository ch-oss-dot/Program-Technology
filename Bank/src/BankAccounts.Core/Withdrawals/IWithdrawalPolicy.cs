namespace BankAccounts.Core.Withdrawals;

public interface IWithdrawalPolicy
{
    WithdrawalDecition Evaluate(decimal currentBalance, decimal amount, decimal minimumBalance);
}
