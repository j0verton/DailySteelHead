using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class NameTheIntervalGame
    {
        public IntervalFretboard Fretboard;

        public List<int> QuestionNumbers
        {
            get
            {
                var noteCoordinates = new List<int>();
                int frets = Fretboard.ChromaticFretboard.Fretboard.Count();
                int strings = Fretboard.ChromaticFretboard.Tuning.Notes.Split(',').Count();
                noteCoordinates.Add(new Random().Next(frets));
                noteCoordinates.Add(new Random().Next(strings));
                return noteCoordinates;
            }
        }

    }
}
