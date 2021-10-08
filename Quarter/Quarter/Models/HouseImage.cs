using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class HouseImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int HouseId { get; set; }
        public bool? PosterStatus { get; set; }
        public House House { get; set; }
    }
}
