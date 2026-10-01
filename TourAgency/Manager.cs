using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgency
{
    public class Manager
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set;  }

        public bool IsExperienced
        {
            get { return Experience > 3; }
        }
        public string GetInfo()
        {
            return FullName + " (" + Experience + " лет опыта)";
        }
    }
}
