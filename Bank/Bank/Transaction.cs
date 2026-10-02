namespace Bank;
/// <summary>
/// Тип данных, который запрещает менять состояние объекта
/// </summary>
/// <param name="Amount">Сумма транзакции</param>
/// <param name="Date">Дата транзакции</param>
/// <param name="Note">Заметка транзакции</param>
public record Transaction(decimal Amount, DateTime Date, string Note);


