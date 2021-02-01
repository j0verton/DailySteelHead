using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    public class Tuning
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Notes { get; set; }


        


    }
}
