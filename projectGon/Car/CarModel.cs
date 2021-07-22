using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectGon.Car
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public string Available { get; set; }
        public string Picture { get; set; }
        public int PricePerDay { get; set; }
        public int LateCost { get; set; }
    }
}
