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
                TimeSpan length = Streak.LastUpdate.AddDays(1) - Streak.DateBegun;
                return length;
            }
        }
    }
}
