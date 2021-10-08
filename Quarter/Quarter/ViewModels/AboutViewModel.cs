using Quarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.ViewModels
{
    public class AboutViewModel
    {
        public List<Team> Teams { get; set; }
        public List<Setting> Settings { get; set; }
        public List<About> Abouts { get; set; }
        public List<Service> Services { get; set; }
    }
}
