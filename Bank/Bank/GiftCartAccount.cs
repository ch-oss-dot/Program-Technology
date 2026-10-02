namespace Bank;

public class GiftCartAccount:BankAccount
{
    private readonly decimal _monthlyDeposit = 0;
    //_monthlyDeposit - параметр по уммолчанию (принимает 0)
    // при создании new GiftCartAccount("Yana", 1000); => _monthlyDeposit = 0
    // new GiftCartAccount("Yana", 1000, 5000);=> _monthlyDeposit = 5000
    public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance) => _monthlyDeposit = monthlyDeposit;
    public override void PerformMonthAndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposite(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
        }
    }
    public override string ToString()
    {
        return base.ToString()+$"monthlyDeposit: {_monthlyDeposit}";
    }
}
