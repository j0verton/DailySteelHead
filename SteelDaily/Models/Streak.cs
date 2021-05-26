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
        [Column("id")]
        public int Id { get; set; }
        [Column("userprofileid")]
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        [Column("datebegun")]
        public DateTime DateBegun { get; set; }
        [Column("lastupdate")]
        public DateTime LastUpdate { get; set; }
    }
}
