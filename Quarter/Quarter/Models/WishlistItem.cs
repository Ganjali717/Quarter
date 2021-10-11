using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public string AppUserId { get; set; }
        public int Count { get; set; }


        public House House { get; set; }
        public AppUser AppUser { get; set; }
    }
}
