namespace Bank;
/// <summary>
/// Кредитный счёт с лимитом, при уходе в минус начисляются проценты
/// </summary>
public class LineOfCreditAccount : BankAccount
{
    /// <summary>
    /// Создаёт кредитный счёт с заданным лимитом
    /// </summary>
    /// <param name="name">ФИО владельца</param>
    /// <param name="initialBalance">Начальный баланс</param>
    /// <param name="creditLimit">Кредитный лимит</param>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)

    {

    }
    /// <summary>
    ///  Начисляет 7% на отрицательный баланс (проценты по кредиту)
    /// </summary>
    public override void PerformMonthAndTransaction()
    {
        if (Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.UtcNow, "Charge month interest");
        }
    }
    /// <summary>
    /// При превышении лимита создаёт транзакцию комиссии за овердрафт (−20)
    /// </summary>
    /// <param name="isOverdrawn"> Признак превышения лимита </param>
    /// <returns>Транзакция комиссии или <c>null</c>, если превышения нет</returns>
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;

}
