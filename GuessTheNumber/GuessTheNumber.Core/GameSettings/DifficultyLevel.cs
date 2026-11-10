namespace GuessTheNumber.Core.GameSettings;

public class DifficultyLevel
{
    public int MinValue { get; }
    public int MaxValue { get; }
    public int MaxAttempts { get; }

    public DifficultyLevel(int minValue, int maxValue, int maxAttempts)
    {
        MinValue = minValue;
        MaxValue = maxValue;
        MaxAttempts = maxAttempts;
    }
}