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

        // Выбираем сложность
        DifficultyLevel settings = ChooseDifficulty();

        var session = new GameSession(settings, generator);

        System.Console.WriteLine($"\nВыбран уровень: {settings.Name}");
        System.Console.WriteLine($"Угадайте число от {settings.MinValue} до {settings.MaxValue}. У вас {settings.MaxAttempts} попыток.");

        while (!session.IsGameOver)
        {
            System.Console.Write("Ваш вариант: ");

            if (int.TryParse(System.Console.ReadLine(), out int guess))
            {
                var result = session.MakeGuess(guess);

                switch (result)
                {
                    case GameResult.TooLow:
                        System.Console.WriteLine("Ваше число меньше.");
                        break;
                    case GameResult.TooHigh:
                        System.Console.WriteLine("Ваше число больше.");
                        break;
                    case GameResult.Win:
                        System.Console.WriteLine($" Неплохо! Вы угадали за {session.CurrentAttempt} попыток.");
                        break;
                    case GameResult.OutOfAttempts:
                        System.Console.WriteLine("Ты тупой! Попытки закончились.");
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("Пожалуйста, введите корректное число.");
            }
        }
    }

    // Меню выбора сложности
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
            default:
                System.Console.WriteLine("Неверный выбор. Выбран обычный уровень.");
                return DifficultyLevel.Normal;
        }
    }

    // Создание пользовательских настроек
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