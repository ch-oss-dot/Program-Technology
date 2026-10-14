using System;
using System.Collections.Generic;
using System.Text;
namespace Bank;

/// <summary>
/// Журнал аудита банковских операций.
/// </summary>
public class AuditLog
{
    private List<string> _entries = new List<string>();

    /// <summary>
    /// Записывает операцию в журнал.
    /// </summary>
    /// <param name="accountNumber">Номер счёта.</param>
    /// <param name="type">Тип операции: Deposit, Withdrawal, Interest.</param>
    /// <param name="amount">Сумма операции.</param>
    /// <param name="date">Дата операции.</param>
    public void Record(string accountNumber, string type, decimal amount, DateTime date)
    {
        _entries.Add($"{date:dd.MM.yyyy} | {accountNumber} | {type} | {amount}");
    }

    /// <summary>
    /// Возвращает журнал в виде текста.
    /// </summary>
    public string GetLog()
    {
        var sb = new StringBuilder();
        foreach (var e in _entries)
        {
            sb.AppendLine(e);
        }
        return sb.ToString();
    }
}