using Quarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.ViewModels
{
    public class HouseViewModel
    {
        public List<House> Houses { get; set; }
        public List<Ameniti> Amenitis { get; set; }
        public List<Team> Teams { get; set; }
        public List<HouseStatus> HouseStatuses { get; set; }
        public List<HouseType> HouseTypes { get; set; }

        public PagenatedList<House> Evler { get; set; }

        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }


    }
}
