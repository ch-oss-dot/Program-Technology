using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GuessTheNumber.Core.Statistics
{
    public class FileStatisticsRepository : IStatisticsRepository
    {
        private readonly string _filePath;
        private readonly List<GameResultData> _sessionStats = new();

        public FileStatisticsRepository(string filePath = "stats.txt")
        {
            _filePath = filePath;
        }

        public void SaveResult(GameResultData result)
        {
            // Сохраняем в список текущей сессии для подсчета avg/min/max
            _sessionStats.Add(result);

            // Дописываем результат в файл формат: Сложность;Попытки
            File.AppendAllText(_filePath, $"{result.Difficulty};{result.Attempts}{Environment.NewLine}");
        }

        public string GetFormattedStats()
        {
            if (_sessionStats.Count == 0) return "Статистики пока нет.";

            var min = _sessionStats.Min(s => s.Attempts);
            var max = _sessionStats.Max(s => s.Attempts);
            var avg = _sessionStats.Average(s => s.Attempts);

            return $"Статистика сессии: Игр = {_sessionStats.Count}, Мин = {min}, Макс = {max}, Среднее = {avg:F1}";
        }
    }
}