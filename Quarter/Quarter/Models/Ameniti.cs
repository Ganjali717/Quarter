using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class Ameniti
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HouseAmeniti> HouseAmenitis { get; set; }
    }
}
