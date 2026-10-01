namespace TourAgency
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 — InMemoryRepository");
            Console.WriteLine("2 — CsvRepository (папка data)");
            Console.Write("Ваш выбор: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неверный выбор");
                return;
            }

            List<Country> countries;
            List<Manager> managers;
            List<Tour> tours;

            try
            {
                switch (choice)
                {
                    case 1:
                        InMemoryRepository mem = new InMemoryRepository();
                        countries = mem.GetCountries();
                        managers = mem.GetManagers();
                        tours = mem.GetTours();
                        break;
                    case 2:
                        CsvRepository csv = new CsvRepository("data");
                        countries = csv.GetCountries();
                        managers = csv.GetManagers();
                        tours = csv.GetTours();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при загрузке данных: " + ex.Message);
                return;
            }
            if (countries.Count == 0 || managers.Count == 0 || tours.Count == 0)
            {
                Console.WriteLine("Данные не загружены. Работа программы остановлена.");
                return;
            }



            Console.WriteLine();

            // 1
            Manager foundManager = FindManager(tours, managers, "\"Пляжный отдых\"");
            Console.WriteLine("1. FindManager: " + (foundManager != null ? foundManager.GetInfo() : "null"));

            // 2
            Country foundCountry = FindCountry(tours, countries, "\"Пляжный отдых\"");
            Console.WriteLine("2. FindCountry: " + (foundCountry != null ? foundCountry.GetInfo() : "null"));

            // 3
            Console.WriteLine("3. GetTotalDays: " + GetTotalDays(tours));

            // 4
            Country popular = GetMostPopularCountry(tours, countries);
            Console.WriteLine("4. GetMostPopularCountry: " + (popular != null ? popular.GetInfo() : "null"));

            // 5
            Console.WriteLine("5. PrintAllTours:");
            PrintAllTours(tours, managers, countries);
        }


        static Manager FindManager(List<Tour> tours, List<Manager> managers, string tourName)
        {

            if (tours == null || managers == null) return null;
            for (int i = 0; i < tours.Count; i++)
            {
                if (tours[i].Name == tourName)
                {
                    for (int j = 0; j < managers.Count; j++)
                    {
                        if (managers[j].Id == tours[i].ManagerId)
                            return managers[j];
                    }
                }
            }
            return null;
        }

        static Country FindCountry(List<Tour> tours, List<Country> countries, string tourName)
        {
            if (tours == null || countries == null) return null;
            for (int i = 0; i < tours.Count; i++)
            {
                if (tours[i].Name == tourName)
                {
                    for (int j = 0; j < countries.Count; j++)
                    {
                        if (countries[j].Id == tours[i].CountryId)
                            return countries[j];
                    }
                }
            }
            return null;
            
        }

        static int GetTotalDays(List<Tour> tours)
        {
            int total = 0;
            for (int i = 0; i < tours.Count; i++)
                total += tours[i].Days;
            return total;
        }

        static Country GetMostPopularCountry(List<Tour> tours, List<Country> countries)
        {
            if (tours.Count == 0) return null;

            Country best = null;
            int bestCount = -1;

            for (int i = 0; i < countries.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < tours.Count; j++)
                {
                    if (tours[j].CountryId == countries[i].Id)
                        count++;
                }
                if (count > bestCount)
                {
                    bestCount = count;
                    best = countries[i];
                }
            }
            return best;
        }

        static void PrintAllTours(List<Tour> tours, List<Manager> managers, List<Country> countries)
        {
            for (int i = 0; i < tours.Count; i++)
            {
                string managerName = "---";
                for (int j = 0; j < managers.Count; j++)
                {
                    if (managers[j].Id == tours[i].ManagerId)
                    {
                        managerName = managers[j].FullName;
                        break;
                    }
                }

                string countryName = "---";
                for (int j = 0; j < countries.Count; j++)
                {
                    if (countries[j].Id == tours[i].CountryId)
                    {
                        countryName = countries[j].Name;
                        break;
                    }
                }

                Console.WriteLine("\"" + tours[i].GetInfo() + "\" --- менеджер " +
                    managerName + ", страна \"" + countryName + "\"");
            }
        }
    }
}
