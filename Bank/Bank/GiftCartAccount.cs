namespace Bank;

public class GiftCartAccount:BankAccount
{
    private readonly decimal _monthlyDeposit = 0m;

    //monthlyDeposit - параметр по умолчанию, принимает 0, 
    //при создании объекта new GiftCartAccount("Yana",1000) -monthlyDeposit =0
    //new GiftCartAccount("Yana",1000., 5000) -monthlyDeposit =5000
    public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit=0)
        :base(name, initialBalance)
        => _monthlyDeposit = monthlyDeposit;

    public override void PerformMonthAndTransaction()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposite(_monthlyDeposit, DateTime.UtcNow, "Add monthly depisit");
        }
    }
    public override string ToString()
    {
        return base.ToString() + $"monyhly deposit: {_monthlyDeposit}";
    }
}
