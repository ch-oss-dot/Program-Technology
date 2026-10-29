namespace BankAccounts.Core.AccountNumbers;

//Генерация номеров аккаунтов - отдельная ответственность не должна быть внутри счета(SRP)
public interface IAccountNumberGenerator
{
    string Next();
}
