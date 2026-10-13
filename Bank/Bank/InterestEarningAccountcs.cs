
namespace Bank;

public class InterestEarningAccountcs: BankAccount
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="initialBalance"></param>
    public InterestEarningAccountcs(string name, decimal initialBalance) : base(name, initialBalance) 
    { 
    
    }
    //override позволяет в дочернем классе определить новую реалиацию метода 
    public override void PerformMonthAndTransaction()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposite(interest,DateTime.UtcNow, "Apply month interest");
        }
    }
}
