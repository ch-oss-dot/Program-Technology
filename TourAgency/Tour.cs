using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgency
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name {  get; set; }

        public int CountryId { get; set; }
        public int ManagerId { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }
        public decimal PricePerDay
        {
            get 
            {
                if (Days <= 0) return 0;
                return Price/Days;
            }
        }
        public bool IsLong
        {
            get { return Days > 10; }
        }
        public string GetInfo()
        {
            return Name + " (" + Days + " дней, " + Price + " руб.)";
        }

        public Tour(int id, string name, int countryid, int managerid, decimal price, int days)
        {
            if (days <= 0)
            {
                throw new ArgumentException("Days must be positive");
            }
            Id = id;
            Name = name;
            CountryId = countryid;
            ManagerId = managerid;
            Price = price;
            Days = days;
        }
    }
}
