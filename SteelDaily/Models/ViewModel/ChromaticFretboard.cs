using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class ChromaticFretboard : MusicTheory
    {
        public Tuning Tuning {get; set;}
        public List<List<ChromaticScale>> Fretboard
        {
            get
            {
                List<List<ChromaticScale>> fretboard = new List<List<ChromaticScale>>();
                List<string> fretZeroString = Tuning.Notes.Split(',').ToList();
                var fretZero = new List<ChromaticScale>();
                foreach (string noteString in fretZeroString)
                {
                    fretZero.Add((ChromaticScale)Enum.Parse(typeof(ChromaticScale), noteString));
                }
                fretboard.Add(fretZero);
                for (var i = 0; i < 16; i++)
                {
                    var fret = new List<ChromaticScale>();
                    foreach (ChromaticScale note in fretboard[i])
                    {
                        ChromaticScale newNote = note + 1;
                        if (Convert.ToInt32(newNote) == 13)
                        {
                            newNote = (ChromaticScale)1;
                        }
                        fret.Add(newNote);
                    };
                    fretboard.Add(fret);
                }
                return fretboard;
            }
        }
    }
}
