using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? HouseId { get; set; }
        [StringLength(maximumLength: 100)]
        public string HouseLocation { get; set; }
        public double SalePrice { get; set; }

        public House House { get; set; }
        public Order Order { get; set; }
    }
}
