using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    [Table("game")]
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
}
}
