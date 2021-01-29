using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class InProcessGame
    {
        public string Answer { get; set; }
        public List<int> QuestionNumbers
        {
            get
            {
                var noteCoordinates = new List<int>();
                int frets = Fretboard.Fretboard.Count();
                int strings = Fretboard.Tuning.Notes.Split(',').Count();
                noteCoordinates.Add(new Random().Next(frets));
                noteCoordinates.Add(new Random().Next(strings));
                return noteCoordinates;
            }
        }
        public Result Result { get; set; }
        public IntervalFretboard Fretboard 
        {
            get {
                var fretboard = new IntervalFretboard()
                {
                    Key = Result.Key,
                    Tuning = Result.Tuning

                };
                return fretboard;
            }
        }
        public bool Outcome 
        {
            get 
            {
                var question = Result.Questions.Last();
                var correctAnswer = Fretboard.Fretboard[question[0]][question[1]];
                if (Answer == correctAnswer)
                {
                    return true;
                } 
                else 
                {
                    return false;
                }
            
            }
        
        }
    }
}
