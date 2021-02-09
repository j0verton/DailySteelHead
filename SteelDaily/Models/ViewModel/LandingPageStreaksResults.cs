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
        public List<IGame> ResultsForFeed {
            get
            {
                var resultsForFeed = new List<IGame>();
                foreach (Result result in LastTenResults)
                {
                    if (result.GameId == 1 || result.GameId == 2)
                    {
                        var gameObj = new InProcessGame()
                        {
                            Result = result
                        };
                        resultsForFeed.Add(gameObj);
                    }
                    else if (result.GameId == 3)
                    {
                        var gameObj = new UnisonGame()
                        {
                            Result = result
                        };
                        resultsForFeed.Add(gameObj);
                    }
                }
                return resultsForFeed;
            }
        }

    }
}
