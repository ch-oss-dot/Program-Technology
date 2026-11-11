using System;
using GuessTheNumber.Core.GameSettings;
using GuessTheNumber.Core.Randomization;

namespace GuessTheNumber.Core.Gameplay;

public class GameSession
{
    private readonly DifficultyLevel _settings;
    private readonly int _secretNumber;

    public int CurrentAttempt { get; private set; }
    public bool IsGameOver { get; private set; }

    // ТО САМОЕ СОБЫТИЕ (требование задания)
    public event Action<GameEvent>? OnGameEvent;

    public GameSession(DifficultyLevel settings, ISecretNumberGenerator generator)
    {
        _settings = settings;
        _secretNumber = generator.Generate(settings.MinValue, settings.MaxValue);
        CurrentAttempt = 0;
        IsGameOver = false;
    }

    public void MakeGuess(int userNumber)
    {
        if (IsGameOver) return;

        CurrentAttempt++;

        if (userNumber == _secretNumber)
        {
            IsGameOver = true;
            // Уведомляем подписчиков о победе
            OnGameEvent?.Invoke(new GameWonEvent(userNumber, CurrentAttempt));
        }
        else if (CurrentAttempt >= _settings.MaxAttempts)
        {
            IsGameOver = true;
            // Уведомляем подписчиков о проигрыше
            OnGameEvent?.Invoke(new GameLostEvent(_secretNumber, CurrentAttempt));
        }
        else if (userNumber < _secretNumber)
        {
            // Уведомляем, что число меньше
            OnGameEvent?.Invoke(new TooLowEvent(userNumber));
        }
        else
        {
            // Уведомляем, что число больше
            OnGameEvent?.Invoke(new TooHighEvent(userNumber));
        }
    }
}