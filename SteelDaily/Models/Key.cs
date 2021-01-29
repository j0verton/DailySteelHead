using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    public class Key
    {
        public int Id { get; set; }
        [Required]
        public string Root { get; set; }
    }
}
