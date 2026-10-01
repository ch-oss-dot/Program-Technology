using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TourAgency
{
    /// <summary>
    /// Репозиторий, читающий данные из CSV-файлов в папке data.
    /// </summary>
    public class CsvRepository
    {
        private string _basePath;

        /// <summary>
        /// Конструктор принимает базовый путь к папке с CSV.
        /// </summary>
        public CsvRepository(string basePath)
        {
            _basePath = basePath;
        }

        /// <summary>Читает countries.csv и возвращает список стран.</summary>
        public List<Country> GetCountries()
        {
            List<Country> result = new List<Country>();
            string path = Path.Combine(_basePath, "countries.csv");

            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3) continue;

                Country c = new Country();
                c.Id = int.Parse(parts[0]);
                c.Name = parts[1].Trim();
                c.Continent = parts[2].Trim();
                result.Add(c);
            }

            return result;
        }

        /// <summary>Читает managers.csv и возвращает список менеджеров.</summary>
        public List<Manager> GetManagers()
        {
            List<Manager> result = new List<Manager>();
            string path = Path.Combine(_basePath, "managers.csv");

            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 4) continue;

                Manager m = new Manager();
                m.Id = int.Parse(parts[0]);
                m.FullName = parts[1].Trim();
                m.Phone = parts[2].Trim();
                m.Experience = int.Parse(parts[3]);
                result.Add(m);
            }

            return result;
        }

        /// <summary>Читает tours.csv и возвращает список туров.</summary>
        public List<Tour> GetTours()
        {

            List<Tour> result = new List<Tour>();
            string path = Path.Combine(_basePath, "tours.csv");

            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 6) continue;

                int id = int.Parse(parts[0]);
                string name = parts[1].Trim();
                int countryid = int.Parse(parts[2]);
                int managerid = int.Parse(parts[3]);
                decimal price = decimal.Parse(parts[4], CultureInfo.InvariantCulture);
                int days = int.Parse(parts[5]);

                Tour e = new Tour(id, name, countryid, managerid, price, days);
                result.Add(e);
            }

            return result;
        }
        
        

        
    }
}
