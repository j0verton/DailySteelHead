using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    public class Tuning : MusicTheory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Notes { get; set; }


        public List<List<ChromaticScale>> Fretboard 
        {
            get {
                List<List<ChromaticScale>> Fretboard = new List<List<ChromaticScale>>();
                List<string> fretZeroString = Notes.Split(',', ' ').ToList();
                var fretZero = new List<ChromaticScale>();
                foreach (string NoteString in fretZeroString)
                {
                    fretZero.Add((ChromaticScale)Enum.Parse(typeof(ChromaticScale), NoteString));
                }
                Fretboard.Add(fretZero);
                for (var i = 0; i < 22; i++)
                {
                    var fret = new List<ChromaticScale>();
                    foreach (ChromaticScale note in Fretboard[i])
                    {
                        ChromaticScale NewNote = note + 1;
                        if (Convert.ToInt32(NewNote) == 13)
                        {
                            NewNote = (ChromaticScale)1;
                        }
                        fret.Add(NewNote);
                    };
                    Fretboard.Add(fret);
                }
                return Fretboard;
            }
        }


    }
}
