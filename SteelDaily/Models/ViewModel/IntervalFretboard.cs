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
                // converting key from result into enum value
                ChromaticScale root = (ChromaticScale) Enum.Parse(typeof(ChromaticScale), Key);
                //the number of steps the new root is above the key of C 
                int transposition = (int) root - 1 ;
                List <List<string>> fretboard = new List<List<string>>();
                foreach (List<ChromaticScale> fret in ChromaticFretboard.Fretboard)
                {
                    List<string> fretIntervals = new List<string>();
                    foreach (ChromaticScale note in fret)
                    {
                        int intervalHalfSteps = ((int)note - transposition + 12) % 12;
                        if (intervalHalfSteps == 0)
                        {
                            intervalHalfSteps = 12;
                        }
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
