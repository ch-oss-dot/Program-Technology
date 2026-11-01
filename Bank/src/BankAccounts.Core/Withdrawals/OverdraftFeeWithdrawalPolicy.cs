namespace BankAccounts.Core.Withdrawals;

//Политика с овердрафтом: разрешаем, но берем комиссию
public sealed class OverdraftFeeWithdrawalPolicy : IWithdrawalPolicy
{
    private readonly decimal _fee;
    public OverdraftFeeWithdrawalPolicy(decimal fee) => _fee = fee;
    public WithdrawalDecition Evaluate(decimal currentBalance, decimal amount, decimal minimumBalance)
        => currentBalance - amount < minimumBalance ? WithdrawalDecition.AllowWithFee(_fee) : WithdrawalDecition.Allow();
}
