using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class House
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int HouseTypeId { get; set; }
        public int HouseStatusId { get; set; }
        public int CityId { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public double Area { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public int Baths { get; set; }
        [Required]
        public int YearBuilt { get; set; }
        [Required]
        public int Beds { get; set; }
        [Required]
        public double SalePrice { get; set; }
        [Required]
        public bool IsFeatured { get; set; }
        [Required]
        public bool IsRelated { get; set; }
        [Required]
        public int Rate { get; set; }
        public int Floor { get; set; }
        public int? CurrentFloor { get; set; }

        public List<HouseAmeniti> HouseAmenitis { get; set; }
        public List<HouseImage> HouseImages { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Order> Orders { get; set; }
        public Team Team { get; set; }
        public HouseType HouseType { get; set; }
        public HouseStatus HouseStatus { get; set; }
        public City City { get; set; }

        [NotMapped]
        public IFormFile PosterFile { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }

        [NotMapped]
        public List<int> HouseImageIds { get; set; } = new List<int>();

        [NotMapped]
        public List<int> AmenitiIds { get; set; } = new List<int>();

        public List<WishlistItem> WishlistItems { get; set; }

        [NotMapped]

        public bool IsWished { get; set; }
    }
}
