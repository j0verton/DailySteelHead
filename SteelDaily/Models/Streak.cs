using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    [Table("streak")]
    public class Streak
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public DateTime DateBegun { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
