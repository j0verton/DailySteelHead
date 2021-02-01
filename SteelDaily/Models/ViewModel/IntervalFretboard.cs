using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class IntervalFretboard : MusicTheory
    {
        public string Key { get; set; }

        public ChromaticFretboard ChromaticFretboard { get; set; }

        public List<List<string>> IntFretboard
        {
            get
            {
                ChromaticScale root = (ChromaticScale) Enum.Parse(typeof(ChromaticScale), Key);
                int transposition = (int) root - 1;
                List <List<string>> fretboard = new List<List<string>>();
                foreach (List<ChromaticScale> fret in ChromaticFretboard.Fretboard)
                {
                    List<string> fretIntervals = new List<string>();
                    foreach (ChromaticScale note in fret)
                    {
                        int intervalHalfSteps = (int)note - transposition;
                        Intervals interval = (Intervals)intervalHalfSteps;
                        fretIntervals.Add(interval.ToString());
                    }
                    fretboard.Add(fretIntervals);
                }
                return fretboard;
            }
        }

    }
}
