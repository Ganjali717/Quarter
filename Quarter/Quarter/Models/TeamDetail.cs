using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class TeamDetail
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:80)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 80)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Experience { get; set; }
        [StringLength(maximumLength: 100)]
        public string Location { get; set; }
        [StringLength(maximumLength: 100)]
        public string Facebook { get; set; }
        [StringLength(maximumLength: 100)]
        public string Twitter { get; set; }
        [StringLength(maximumLength: 100)]
        public string Linkedin { get; set; }
        [Required]
        [StringLength(maximumLength: 1000)]
        public string Desc { get; set; }


    }
}
