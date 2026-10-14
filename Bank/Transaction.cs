namespace Bank;
/// <summary>
/// Одна банковская операция: сумма, дата, комментарий.
/// Неизменяемая запись (record).
/// </summary>
/// <param name="Amount">Сумма операции. Положительная — пополнение, отрицательная — списание.</param>
/// <param name="Date">Дата операции.</param>
/// <param name="Note">Комментарий к операции.</param>
public record Transaction(decimal Amount, DateTime Date, string Note);

