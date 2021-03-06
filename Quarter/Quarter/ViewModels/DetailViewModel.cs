using Quarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.ViewModels
{
    public class DetailViewModel
    {
        public House Houses { get; set; }

        public List<HouseImage> HouseImages { get; set; }

        public List<Ameniti> Amenitis { get; set; }
        public List<HouseType> HouseTypes { get; set; }
        public List<House> Evler { get; set; }
        public Comment comment { get; set; }

        public List<Comment> komentariya { get; set; }

        public List<HouseAmeniti> HouseAmenitis { get; set; }

    }
}
