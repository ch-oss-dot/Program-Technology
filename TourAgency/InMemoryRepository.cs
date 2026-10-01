using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgency
{
    public class InMemoryRepository
    {
        private List<Country> _countries;
        private List<Manager> _managers;
        private List<Tour> _tours;
        public InMemoryRepository()
        {
            _countries = new List<Country>()
            {
                new Country{Id=1, Name="Турция", Continent="Азия"},
                new Country{Id=2, Name="Италия", Continent="Европа"},
                new Country{Id=3, Name="Египет", Continent="Африка"},
                new Country{Id=4, Name="Швейцария", Continent="Европа"},
                new Country{Id=5, Name="Китай", Continent="Азия"},
            };
            _managers = new List<Manager>() 
            {
                new Manager{Id=1, FullName="Иванова А.А.", Phone="+7-900-111-11-11",Experience=4},
                new Manager{Id=2, FullName="Петров М.Л.", Phone="+7-900-844-55-55", Experience=2},
                new Manager{Id=3, FullName="Сидорова Ф.Р.", Phone="+7-999-111-11-11",Experience=7},
                new Manager{Id=4, FullName="Кузнецов Д.Д.", Phone="+7-999-178-74-77", Experience=0},
                new Manager{Id=5, FullName="Орлова О.О.", Phone="+7-946-561-22-33", Experience=5},
            };
            _tours = new List<Tour>
            { 
                new Tour(1, "Пляжный отдых", 1, 1, 50000,7),
                new Tour(2, "Экскурсионный", 2, 2, 42000, 5),
                new Tour(3, "Пляжный отдых", 1, 1, 65000,10),
                new Tour(4, "Горнолыжный", 2, 3, 80000,14),
                new Tour(5, "Пляжный отдых", 1, 5, 55000,8),
                new Tour(6, "Круиз", 4, 3, 120000,12),
            };
            

        }
        public List<Country> GetCountries()
            {
                return _countries;
            }
        public List<Manager> GetManagers()
            {
                return _managers;
            }

        public List<Tour> GetTours()
            {
                return _tours;
            }
    }
}
