
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Bank;
//BankAccount -  потомок класса Object
public class BankAccount
    {

    private readonly decimal _minimumBalance;
        private List<Transaction> _allTransactions = new List<Transaction>();
        public string Owner { get; private set; } 
        public string Number { get;  }
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

    
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    { 
    }
    /// <summary>
    /// Создает счет с минимальным балансом, который указан
    /// </summary>
    /// <param name="name"> ФИО владельца</param>
    /// <param name="initialBalance">первоначальный баланс </param>
    /// <param name="minimumBalance"> Минимальный допустимый баланс </param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
            Owner = name;
            Number = s_accauntNumberS.ToString();
            s_accauntNumberS++;

        _minimumBalance = minimumBalance;
        if (initialBalance>0)
            MakeDeposite(initialBalance,DateTime.UtcNow, "initial balance"); // this.Balance = initialBalance;
            
            

            
        }
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
    public virtual void PerformMonthAndTransaction()
    {

    }
    //Переопределяем метод базового класса -  класса object
    //ToString - возвращает строку с информацией об объекте

   
    public override string ToString()
    {
        return $"Owner: {Owner}\taccount number: {Number} (тип счёта {GetType()}";
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
        }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="date"></param>
    /// <param name="note"></param>
    /// <exception cref="ArgumentOutOfRangeException ">
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);

        Transaction? withdrawal = new(-amount, date, note);

        _allTransactions.Add(withdrawal);

        if(overdraftTransaction is not null ) 
            _allTransactions.Add(overdraftTransaction);

    }
    // protected - модификатор доступа, который означает, что этот метод можно вызвать только из текущего и дочернего класса 
    // Клиент (внешний код) данный метод вызвать не может 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="isOverDrawn"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
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

