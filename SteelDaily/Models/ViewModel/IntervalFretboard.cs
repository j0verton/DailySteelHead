using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class IntervalFretboard : MusicTheory
    {
        public Key key { get; set; }

        public Tuning tuning { get; set; }

        public List<List<string>> Fretboard
        {
            get
            {
                ChromaticScale root = (ChromaticScale) Enum.Parse(typeof(ChromaticScale), key.Root);
                int transposition = (int) root - 1;
                List <List<string>> Fretboard = new List<List<string>>();
                foreach (List<ChromaticScale> fret in tuning.Fretboard)
                {
                    List<string> fretIntervals = new List<string>();
                    foreach (ChromaticScale note in fret)
                    {
                        int intervalHalfSteps = (int)note - transposition;
                        Intervals interval = (Intervals)intervalHalfSteps;
                        fretIntervals.Add(interval.ToString());
                    }
                    Fretboard.Add(fretIntervals);
                }
                return Fretboard;
            }
        }

    }
}
