namespace GuessTheNumber.Core.Gameplay;

// Базовый класс для всех событий игры
public abstract record GameEvent;

// События, которые могут произойти во время игры
public record TooLowEvent(int UserNumber) : GameEvent;
public record TooHighEvent(int UserNumber) : GameEvent;
public record GameWonEvent(int UserNumber, int AttemptsUsed) : GameEvent;
public record GameLostEvent(int SecretNumber, int AttemptsUsed) : GameEvent;