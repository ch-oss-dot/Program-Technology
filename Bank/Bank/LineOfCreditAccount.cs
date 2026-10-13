namespace Bank;

public class LineOfCreditAccount : BankAccount
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="initialBalance"></param>
    /// <param name="creditLimit"></param>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)

    {

    }

    public override void PerformMonthAndTransaction()
    {
        if (Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.UtcNow, "Charge month interest");
        }
    }

    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;

}
