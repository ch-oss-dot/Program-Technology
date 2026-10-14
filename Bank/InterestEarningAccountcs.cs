
namespace Bank;
/// <summary>
/// Счёт с начислением процентов на остаток
/// </summary>
public class InterestEarningAccountcs: BankAccount
{
    /// <summary>
    /// Создаёт счёт с начислением процентов
    /// </summary>
    /// <param name="name"> ФИО владельца счета </param>
    /// <param name="initialBalance"> начальный баланс </param>
    public InterestEarningAccountcs(string name, decimal initialBalance) : base(name, initialBalance) 
    { 
    
    }
    //override позволяет в дочернем классе определить новую реалиацию метода 
    /// <summary>
    /// Начисляет 2% на остаток, если он превышает 500(проверка)
    /// </summary>
    public override void PerformMonthAndTransaction()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposite(interest,DateTime.UtcNow, "Apply month interest");
        }
    }
}
