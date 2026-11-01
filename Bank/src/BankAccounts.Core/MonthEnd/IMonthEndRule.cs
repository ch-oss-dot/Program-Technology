using BankAccounts.Core.Accounts;

namespace BankAccounts.Core.MonthEnd;

//Каждое правило - это отдельный класс. Новые правила добавляются без изменения старых(Open Closed P, SRP)
public interface IMonthEndRule
{
    void Apply(IAccountOperations account, DateTime asOf);
}
