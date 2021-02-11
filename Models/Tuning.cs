using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    [Table("tuning")]
    public class Tuning
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("notes")]
        public string Notes { get; set; }


        


    }
}
