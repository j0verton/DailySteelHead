using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class LandingPageStreaksResults
    {
        public List<Streak> TopFiveStreaks { get; set; }
        public List<CurrentStreak> LeaderStreaks { 
            get
            {
                var leaderStreaks = new List<CurrentStreak>();
            foreach (Streak streak in TopFiveStreaks)
                {
                    var streakObj = new CurrentStreak()
                    {
                        Streak = streak
                    };
                leaderStreaks.Add(streakObj);
                }
                return leaderStreaks;
            }
        }

        public List<Result> LastTenResults { get; set; }
        public List<InProcessGame> c {
            get
            {
                var resultsForFeed = new List<InProcessGame>();
                foreach (Result result in LastTenResults)
                {
                    var gameObj = new InProcessGame()
                    {
                        Result = result
                    };
                    resultsForFeed.Add(gameObj);
                }
                return resultsForFeed;
            }
        }

    }
}
