using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    [Table("scale")]
    public class Scale
    {
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; }
        [Column("pattern")]
        public string Pattern { get; set; }

    }
}
