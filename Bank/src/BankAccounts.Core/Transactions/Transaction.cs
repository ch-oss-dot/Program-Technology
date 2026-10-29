namespace BankAccounts.Core.Transactions;

//Прстой DTO(data transfer object): сумма, дата, примечание
public sealed record Transaction(decimal Amount, DateTime Date, string Note);
