using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class ServiceDetail
    {
        public int Id { get; set; }
        public string BigDesc1 { get; set; }
        public string BigDesc2 { get; set; }
        [StringLength(maximumLength:100)]
        public string Image { get; set; }

        [NotMapped]
        public IFormFile FileImage { get; set; }
    }
}
