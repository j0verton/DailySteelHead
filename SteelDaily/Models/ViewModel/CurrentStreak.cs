using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class CurrentStreak
    {
        public Streak Streak { get; set; }
        public TimeSpan Length 
        {
            get {
                TimeSpan length = Streak.LastUpdate - Streak.DateBegun;
                return length
            }
        }
    }
}
