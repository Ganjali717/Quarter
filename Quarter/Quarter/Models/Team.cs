using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public int TeamDetailId { get; set; }

        public TeamDetail teamDetail { get; set; }

        [NotMapped]
        public IFormFile FileImage { get; set; }
    }
}
