namespace BankAccounts.Core.Withdrawals;

//Единый контракт для всех политик снятия: возвращаем решение, а не выбрасываем исключения
//это устраняет LSP между базовым и переопределенным методом
public sealed record WithdrawalDecition(bool IsAllowed,decimal Fee, string? RejectionReason)
{
    public static WithdrawalDecition Allow() => new(true, 0m, null);
    public static WithdrawalDecition AllowWithFee(decimal fee) => new(true, fee, null);

    public static WithdrawalDecition Reject(string reason) => new(false, 0m, reason);
}
