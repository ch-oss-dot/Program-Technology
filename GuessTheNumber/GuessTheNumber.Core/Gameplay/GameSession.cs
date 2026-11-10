using GuessTheNumber.Core.GameSettings;
using GuessTheNumber.Core.Randomization;

namespace GuessTheNumber.Core.Gameplay
{
    public class GameSession
    {
        private readonly DifficultyLevel _settings;
        private readonly int _secretNumber;

        public int CurrentAttempt { get; private set; }
        public bool IsGameOver { get; private set; }

        public GameSession(DifficultyLevel settings, ISecretNumberGenerator generator)
        {
            _settings = settings;
            _secretNumber = generator.Generate(settings.MinValue, settings.MaxValue);
            CurrentAttempt = 0;
            IsGameOver = false;
        }

        public GameResult MakeGuess(int userNumber)
        {
            // Если игра уже закончена, ничего не делаем
            if (IsGameOver) return GameResult.Win; 

            CurrentAttempt++;

            // Проверка на победу
            if (userNumber == _secretNumber)
            {
                IsGameOver = true;
                return GameResult.Win;
            }

            // Проверка на проигрыш (закончились попытки)
            if (CurrentAttempt >= _settings.MaxAttempts)
            {
                IsGameOver = true;
                return GameResult.OutOfAttempts;
            }

            // Подсказки
            return userNumber < _secretNumber ? GameResult.TooLow : GameResult.TooHigh;
        }
    }
}