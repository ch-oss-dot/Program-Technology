namespace BankAccounts.Core.Time;

//публичный класс от котого нельзя унаследоваться
//Реализация для продакшена: берет реальное время
public sealed class SystemClock : IClock
{
    public DateTime Now => DateTime.UtcNow;
}
