using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeAware.Models
{
    public class CrimeData
    {
        //Crimes
        public int DrugTrafficking { get; set; }
        public int HumanTrafficking { get; set; }
        public int Fraud { get; set; }
        public int Kidnapping { get; set; }
        public int WildlifePoaching { get; set; }
        public int SexualHarassment { get; set; }
        public int IllegalTrade { get; set; }
        public int Others { get; set; }

        //Geo-political zones
        public int NorthCentral { get; set; }
        public int NorthWest { get; set; }
        public int NorthEast { get; set; }
        public int SouthSouth { get; set; }
        public int SouthEast { get; set; }
        public int SouthWest { get; set; }
    }
}
