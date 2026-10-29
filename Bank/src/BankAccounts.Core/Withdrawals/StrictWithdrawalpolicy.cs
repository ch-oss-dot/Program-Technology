namespace BankAccounts.Core.Withdrawals;

//политика по умолчанию: если баланс ниже минимума - отклоняем
public sealed class StrictWithdrawalpolicy: IWithdrawalPolicy
{
    public WithdrawalDecition Evaluate(decimal currentBalance, decimal amount, decimal minimumBalance) => currentBalance - amount < minimumBalance
        ? WithdrawalDecition.Reject("Not sufficient rubls for this withdrawal")
        : WithdrawalDecition.Allow();
}
