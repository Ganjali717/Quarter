using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string Image { get; set; }
        [StringLength(maximumLength: 50)]
        public string MiniTitle { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Title1 { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Title2 { get; set; }
        [StringLength(maximumLength: 500)]
        public string Desc { get; set; }
        public string RedirectUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
