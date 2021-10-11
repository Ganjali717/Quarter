using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<Ameniti> Amenitis { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<HouseImage> HouseImages { get; set; }
        public DbSet<HouseAmeniti> HouseAmenitis { get; set; }
        public DbSet<HouseStatus> HouseStatuses { get; set; }
        public DbSet<HouseType> HouseTypes { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<WishlistItem> WishlistItems { get; set; }
    }
}
