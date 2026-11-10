using System;
using GuessTheNumber.Core.Gameplay;
using GuessTheNumber.Core.GameSettings;
using GuessTheNumber.Core.Randomization;

namespace GuessTheNumber.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new RandomSecretNumberGenerator();
            // Пока задаем настройки жестко (1-100, 3 попытки)
            var settings = new DifficultyLevel(1, 100, 3); 
            var session = new GameSession(settings, generator);

            Console.WriteLine($"Угадайте число от {settings.MinValue} до {settings.MaxValue}. У вас {settings.MaxAttempts} попыток.");

            while (!session.IsGameOver)
            {
                Console.Write("Ваш вариант: ");
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    var result = session.MakeGuess(guess);

                    switch (result)
                    {
                        case GameResult.TooLow:
                            Console.WriteLine("Ваше число меньше.");
                            break;
                        case GameResult.TooHigh:
                            Console.WriteLine("Ваше число больше.");
                            break;
                        case GameResult.Win:
                            Console.WriteLine($"Победа! Вы угадали за {session.CurrentAttempt} попыток.");
                            break;
                        case GameResult.OutOfAttempts:
                            Console.WriteLine("Вы проиграли! Попытки закончились.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите корректное число.");
                }
            }
        }
    }
}