using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    public class Streak
    {
        public int id { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
