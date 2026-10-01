using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgency
{
    /// <summary>
    /// Здесь написать, что делает класс или метод.
    /// </summary>
    public class Country()
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }//доступный всем, "автосвойство" которое можно читать и записывать(делать что хочу)

        public string Name { get; set; }
        public string Continent {  get; set; }

        public bool IsEurope//вычисляемое св-во не хранит никакое значение, мы просто когда обращаемся к нему считаем значение
        {
            get { return Continent == "Европа"; }//сравнение вернет true false
        }

        public string GetInfo()
        {
            return Name + (" ") +"(" + Continent +")";//чтобы континент был в скобках
        }
    }
    
}
