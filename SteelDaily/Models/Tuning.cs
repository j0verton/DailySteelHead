using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    public class Tuning
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

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

        public enum ChromaticScale 
        {
        C = 1, Db = 2 , D = 3, Eb = 4, E = 5, F = 6, Gb = 7, G = 8, Ab = 9, A = 10, Bb = 11, B = 12
        }
    }

    public static class Extensions
    {

        //public static T Next<T>(this T src) where T : struct
        //{
        //    if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

        //    T[] Arr = (T[])Enum.GetValues(src.GetType());
        //    int j = Array.IndexOf<T>(Arr, src) + 1;
        //    return (Arr.Length == j) ? Arr[0] : Arr[j];
        //}

        //public static ChromaticScale GetNextNote(this ChromaticScale note)
        //{
        //    switch (note)
        //    {
        //        case Ab:
        //            return A;
        //        case A:
        //            return Bb;
        //        case Bb:
        //            return C;
        //        case C:
        //            return Db;
        //        case Db:
        //            return D;
        //        case D:
        //            return Eb;
        //        case Eb
        //            return E;
        //        case E:
        //            return F;
        //        case F:
        //            return Gb
        //        case Gb:
        //            return G;
        //        case G:
        //            return Ab;

        //        default:
        //            throw new IndexOutOfRangeException();
        //    }
        //}


    }
}
