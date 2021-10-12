using Quarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Setting> Settings { get; set; }
        public List<Service> Services { get; set; }
        public List<House> Houses { get; set; }
        public List<Ameniti> Amenitis { get; set; }
        public Order LastOrder { get; set; }
    }
}
