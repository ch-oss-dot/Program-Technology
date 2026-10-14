namespace Bank;

/// <summary>
/// Сервис перевода денег между счетами.
/// </summary>
public class TransferService
{
    /// <summary>
    /// Переводит указанную сумму со счёта <paramref name="from"/> на счёт <paramref name="to"/>.
    /// </summary>
    /// <param name="from">Счёт-источник.</param>
    /// <param name="to">Счёт-получатель.</param>
    /// <param name="amount">Сумма перевода. Должна быть положительной.</param>
    /// <param name="date">Дата операции.</param>
    /// <exception cref="ArgumentNullException">Если <paramref name="from"/> или <paramref name="to"/> равны null.</exception>
    /// <exception cref="InvalidOperationException">Если <paramref name="from"/> и <paramref name="to"/> — один и тот же счёт.</exception>
    public void Transfer(BankAccount from, BankAccount to, decimal amount, DateTime date)
    {
        if (from == null) throw new ArgumentNullException(nameof(from));
        if (to == null) throw new ArgumentNullException(nameof(to));
        if (from == to) throw new InvalidOperationException("Нельзя переводить на тот же счёт");

        from.MakeWithdrawal(amount, date, "Перевод (списание)");
        to.MakeDeposite(amount, date, "Перевод (зачисление)");
    }
}