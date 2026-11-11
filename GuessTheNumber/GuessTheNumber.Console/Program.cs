using System;
using GuessTheNumber.Core.Gameplay;
using GuessTheNumber.Core.GameSettings;
using GuessTheNumber.Core.Randomization;

namespace GuessTheNumber.Console;

internal class Program
{
    static void Main(string[] args)
    {
        var generator = new RandomSecretNumberGenerator();
        DifficultyLevel settings = ChooseDifficulty();
        var session = new GameSession(settings, generator);

        // ПОДПИСЫВАЕМСЯ НА СОБЫТИЯ
        session.OnGameEvent += HandleGameEvent;

        System.Console.WriteLine($"\nВыбран уровень: {settings.Name}");
        System.Console.WriteLine($"Угадайте число от {settings.MinValue} до {settings.MaxValue}. У вас {settings.MaxAttempts} попыток.");

        while (!session.IsGameOver)
        {
            System.Console.Write("Ваш вариант: ");

            if (int.TryParse(System.Console.ReadLine(), out int guess))
            {
                session.MakeGuess(guess); // Логика сама вызовет нужное событие
            }
            else
            {
                System.Console.WriteLine("Пожалуйста, введите корректное число.");
            }
        }
    }

    // Обработчик событий
    static void HandleGameEvent(GameEvent e)
    {
        // В зависимости от того, какое событие пришло, выводим текст
        switch (e)
        {
            case TooLowEvent:
                System.Console.WriteLine("Ваше число меньше.");
                break;
            case TooHighEvent:
                System.Console.WriteLine("Ваше число больше.");
                break;
            case GameWonEvent won:
                System.Console.WriteLine($"Победа! Вы угадали за {won.AttemptsUsed} попыток.");
                break;
            case GameLostEvent lost:
                System.Console.WriteLine($"Вы проиграли! Загаданное число было: {lost.SecretNumber}.");
                break;
        }
    }

    static DifficultyLevel ChooseDifficulty()
    {
        System.Console.WriteLine("Выберите уровень сложности:");
        System.Console.WriteLine("1. Легкий (1-10, 5 попыток)");
        System.Console.WriteLine("2. Обычный (1-100, 3 попытки)");
        System.Console.WriteLine("3. Сложный (1-1000, 10 попыток)");
        System.Console.WriteLine("4. Пользовательский");
        System.Console.Write("Ваш выбор (1-4): ");

        string choice = System.Console.ReadLine();

        switch (choice)
        {
            case "1": return DifficultyLevel.Easy;
            case "2": return DifficultyLevel.Normal;
            case "3": return DifficultyLevel.Hard;
            case "4": return CreateCustomLevel();
            default: return DifficultyLevel.Normal;
        }
    }

    static DifficultyLevel CreateCustomLevel()
    {
        System.Console.Write("Введите минимальное число: ");
        int min = int.Parse(System.Console.ReadLine() ?? "1");

        System.Console.Write("Введите максимальное число: ");
        int max = int.Parse(System.Console.ReadLine() ?? "100");

        System.Console.Write("Введите количество попыток: ");
        int attempts = int.Parse(System.Console.ReadLine() ?? "5");

        return new DifficultyLevel("Пользовательский", min, max, attempts);
    }
}