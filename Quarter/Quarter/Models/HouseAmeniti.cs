using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class HouseAmeniti
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int AmenitiId { get; set; }

        public House House { get; set; }
        public Ameniti Ameniti { get; set; }
    }
}
