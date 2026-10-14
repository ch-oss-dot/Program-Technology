namespace Bank;
/// <summary>
/// Подарочная карта — счёт, на который ежемесячно может
/// автоматически добавляться фиксированная сумма
/// </summary>
public class GiftCartAccount:BankAccount
{
    
    private readonly decimal _monthlyDeposit = 0m;

    //monthlyDeposit - параметр по умолчанию, принимает 0, 
    //при создании объекта new GiftCartAccount("Yana",1000) -monthlyDeposit =0
    //new GiftCartAccount("Yana",1000., 5000) -monthlyDeposit =5000
    /// <summary>
    /// Создаёт подарочную карту с необязательным ежемесячным пополнением
    /// </summary>
    /// <param name="name"> ФИО владельца счета </param>
    /// <param name="initialBalance"> Начальный абланс</param>
    /// <param name="monthlyDeposit"> сумма которая добавляется каждый месяц</param>
    public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit=0)
        :base(name, initialBalance)
        => _monthlyDeposit = monthlyDeposit;
    /// <summary>
    /// Пополняет карту на ежемесячную сумму, если она задана
    /// </summary>
    public override void PerformMonthAndTransaction()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposite(_monthlyDeposit, DateTime.UtcNow, "Add monthly depisit");
        }
    }
    /// <summary>
    /// Возвращает описание карты с указанием ежемесячного пополнения
    /// </summary>
    /// <returns>Строка с информацией о счёте и сумме ежемесячного пополнения</returns>
    public override string ToString()
    {
        return base.ToString() + $"monyhly deposit: {_monthlyDeposit}";
    }
}
