namespace GuessTheNumber.Core.GameSettings;

public class DifficultyLevel
{
    public string Name { get; }
    public int MinValue { get; }
    public int MaxValue { get; }
    public int MaxAttempts { get; }

    public DifficultyLevel(string name, int minValue, int maxValue, int maxAttempts)
    {
        Name = name;
        MinValue = minValue;
        MaxValue = maxValue;
        MaxAttempts = maxAttempts;
    }

    // Готовые пресеты (принцип DRY - не повторяемся)
    public static DifficultyLevel Easy => new("Легкий", 1, 10, 5);
    public static DifficultyLevel Normal => new("Обычный", 1, 100, 3);
    public static DifficultyLevel Hard => new("Сложный", 1, 1000, 10);
}