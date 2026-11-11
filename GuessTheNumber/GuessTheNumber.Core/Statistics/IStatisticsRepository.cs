namespace GuessTheNumber.Core.Statistics;

public interface IStatisticsRepository
{
    void SaveResult(GameResultData result);
    string GetFormattedStats();
}