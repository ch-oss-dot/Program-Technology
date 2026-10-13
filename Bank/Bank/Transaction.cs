namespace Bank;
/// <summary>
/// record - тип данных который запрещает менять состояние объекта ( для записей транзакций)
/// </summary>
/// <param name="Amount"> сумма транзакций</param>
/// <param name="Date"> дата транзакций</param>
/// <param name="Note">заметка транзакций</param>
public record Transaction(decimal Amount, DateTime Date, string Note);

