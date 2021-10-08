using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class HouseType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<House> Houses { get; set; } 
    }
}
