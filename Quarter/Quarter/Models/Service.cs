using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        public string Logo { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Desc { get; set; }
        public int ServiceDetailId { get; set; }

        public ServiceDetail serviceDetail { get; set; }
    }
}
