using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Image { get; set; }
        [StringLength(maximumLength: 100)]
        public string Icon { get; set; }
        [StringLength(maximumLength: 100)]
        public string Title { get; set; }
        [StringLength(maximumLength:300)]
        public string Desc { get; set; }
    }
}
