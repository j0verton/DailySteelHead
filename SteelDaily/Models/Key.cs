using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    [Table("key")]
    public class Key
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Root { get; set; }
    }
}
