
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Bank;
/// <summary>
/// Статус клиента банка, с усоовиями обслуживания
/// </summary>
public enum AccountStatus
{
    Regular,//обычный клиент
    Premium,//премиум клиент
    VIP//VIP клиент
}
//BankAccount -  потомок класса Object
/// <summary>
/// Банковский счет клиента, который хранит историю транзакций и рссчитывает баланс как сумму всех операций
/// </summary>
public class BankAccount
    {
    private AuditLog _auditLog = new AuditLog();

    private readonly decimal _minimumBalance;
        private List<Transaction> _allTransactions = new List<Transaction>();
    /// <summary>
    /// Владелец счета 
    /// </summary>
        public string Owner { get; private set; } 
    /// <summary>
    /// Уникальный номер счета, автоматически генерируется при создании
    /// </summary>
        public string Number { get;  }
    

    /// <summary>
    /// Текущий баланс - сумма всех транзакций
    /// </summary>
        public decimal Balance 
        { get
            {
                decimal balance = 0;
                foreach (var transactions in _allTransactions)
                { 
                    balance += transactions.Amount;
                }
                return balance;
            }
    
        }
        private static int s_accauntNumberS = 1000000000;
    /// <summary>
    /// Статус клиента банка, с усоовиями обслуживания
    /// </summary>
        public AccountStatus Status { get; set; }

    /// <summary>
    /// Создает счет с минимальным балансом, котрый равен нулю
    /// </summary>
    /// <param name="name"> ФИО владельца </param>
    /// <param name="initialBalance"> Начальный баланс </param>
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    { 
    }
    /// <summary>
    /// Создает счет с минимальным балансом, равным нулю
    /// </summary>
    /// <param name="name"> ФИО владельца</param>
    /// <param name="initialBalance"> начальный баланс </param>
    /// <param name="minimumBalance"> Минимальный допустимый баланс </param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance, AccountStatus status = AccountStatus.Regular)
    {
            Owner = name;
            Number = s_accauntNumberS.ToString();
            s_accauntNumberS++;

        _minimumBalance = minimumBalance;
        if (initialBalance>0)
            MakeDeposite(initialBalance,DateTime.UtcNow, "initial balance"); // this.Balance = initialBalance;
            
            

            
    }
    /// <summary>
    /// Формирование истории в виде текстовой таблицы
    /// </summary>
    /// <returns> Строка с таблицей всех транзакций счета </returns>
    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions )
        {
            balance += item.Amount;
            report.AppendLine($""+
                $"{item.Date.ToShortDateString()}\t"+
                $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();

    }
    // virtual - ключевое слово, позволяющее в дочернем классе предоставить другую реализацию этому методу 
    /// <summary>
    /// выполняет ежемесячные операции. переопределяется в классах потомках
    /// </summary>
    public virtual void PerformMonthAndTransaction()
    {
        if (Status == AccountStatus.Regular)
        {
            MakeWithdrawal(50m, DateTime.UtcNow, "Комиссия за обслуживание");
        }
        else if (Status == AccountStatus.Premium)
        {
            if (Balance > 10000m)
            {
                decimal interest = (Balance - 10000m) * 0.01m;
                MakeDeposite(interest, DateTime.UtcNow, "Проценты Premium");
            }
        }
        else if (Status == AccountStatus.VIP)
        {
            if (Balance > 10000m)
            {
                decimal interest = (Balance - 10000m) * 0.003m;
                MakeDeposite(interest, DateTime.UtcNow, "Проценты VIP");
            }
        }
    }
    //Переопределяем метод базового класса -  класса object
    //ToString - возвращает строку с информацией об объекте

    /// <summary>
    /// возвращает строку с информацией об объекте(владелец, номер, тип)
    /// </summary>
    /// <returns> строка с информацией о счете </returns>
    public override string ToString()
    {
        return $"Owner: {Owner}\taccount number: {Number} (тип счёта {GetType()})";
    }

    /// <summary>
    /// Пополняет счёт на указанную сумму.
    /// </summary>
    /// <param name="amount">Сумма пополнения. Должна быть положительной.</param>
    /// <param name="date">Дата операции.</param>
    /// <param name="note">Комментарий к операции.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Бросается, если <paramref name="amount"/> меньше или равен нулю.
    /// </exception>
    public void MakeDeposite  (decimal amount, DateTime date, string note)
    {
         if(amount<=0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposite must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
        _auditLog.Record(Number, "Deposit", amount, date);
    }
    /// <summary>
    /// Списывает указанную сумму со счета. При выходе за минимальный баланс вызывает <see cref="CheckWithdrawalLimit"/>
    /// </summary>
    /// <param name="amount"> Сумма списания, должна быть положительной</param>
    /// <param name="date"> дата операции </param>
    /// <param name="note"> Комментарий к операции </param>
    /// <exception cref="ArgumentOutOfRangeException "> брасается
    /// если <paramref name="amount"/> меньше или равен нулю
    /// </exception>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);

        Transaction? withdrawal = new(-amount, date, note);

        _allTransactions.Add(withdrawal);

        if(overdraftTransaction is not null ) 
            _allTransactions.Add(overdraftTransaction);
        // Кэшбэк 5% для VIP тут, так как на все списания
        if (Status == AccountStatus.VIP)
        {
            decimal cashback = amount * 0.05m;
            MakeDeposite(cashback, date, "VIP cashback");
        }
        _auditLog.Record(Number, "Withdrawal", amount, date);

        if (overdraftTransaction is not null)
            _auditLog.Record(Number, "Withdrawal", Math.Abs(overdraftTransaction.Amount), date);

    }
    // protected - модификатор доступа, который означает, что этот метод можно вызвать только из текущего и дочернего класса 
    // Клиент (внешний код) данный метод вызвать не может 
    /// <summary>
    /// Проверяет, не вышел ли счёт за минимальный баланс. Базовая
    /// реализация выбрасывает исключение, если баланс превышен.
    /// В потомках может быть переопределена.
    /// </summary>
    /// <param name="isOverDrawn">Признак того, что баланс ниже минимального.</param>
    /// <returns>Дополнительная транзакция или <c>null</c>, если её нет.</returns>
    /// <exception cref="InvalidOperationException">
    /// Бросается, если <paramref name="isOverDrawn"/> равно <c>true</c>.
    /// </exception>
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverDrawn)
    {
        if (isOverDrawn)
        {
            throw new InvalidOperationException("Not sufficient rubls for this withdrawl");

        }
        else 
        {
            // default содержит значение по умолчанию, так как тип возвращаемого значения - ссылочный, то эта переменная возрашает null
            return default;// == return null;
        }
    }

}

