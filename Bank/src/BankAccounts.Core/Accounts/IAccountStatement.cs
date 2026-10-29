using BankAccounts.Core.Transactions;

namespace BankAccounts.Core.Accounts;

//ISP : клиенты зависят только от того, что им реального нужно
public interface IAccountStatement
{
    IReadOnlyList<Transaction> Transactions { get; }
}
