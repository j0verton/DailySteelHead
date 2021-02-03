using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class InProcessGame : NameTheIntervalGame
    {
        public List<int> QuestionNumbers
        {
            get
            {
                var noteCoordinates = new List<int>();
                int frets = Fretboard.IntFretboard.Count();
                int strings = Fretboard.ChromaticFretboard.Tuning.Notes.Split(',').Count();
                noteCoordinates.Add(new Random().Next(frets));
                noteCoordinates.Add(new Random().Next(strings));
                return noteCoordinates;
            }
        }
        public Result Result { get; set; }
        public override IntervalFretboard Fretboard 
        {
            get {
                var fretboard = new IntervalFretboard()
                {
                    Key = Result.Key,
                    ChromaticFretboard = new ChromaticFretboard() 
                    { 
                        Tuning = Result.Tuning
                    } 

                };
                return fretboard;
            }
        }
        public List<string> AnswerList { 
            get
            {
                return Result.Answers.Split(',').ToList();
            }
        }
        public List<bool?> Outcomes 
        { get
            {
                var outcomes = new List<bool?>();
                var answerList = Result.Answers.Split(',').ToList();
                for (int i = 0; i < answerList.Count(); i++) 
                {
                    var question = Questions[i];
                    var correctAnswer = Fretboard.IntFretboard[question[0]][question[1]];
                    if (AnswerList[i] == correctAnswer)
                    {
                        outcomes.Add(true);
                    }
                    else
                    {
                        outcomes.Add(false);
                    }
                }
                return outcomes;
            } 
        }

        public List<List<int>> Questions 
        {
            get
            {
                var questions = new List<List<int>>();
                var wholeList = Result.Questions.Split(',').ToList();
                for (int i = 0; i < wholeList.Count(); i+=2)
                {
                    var questionPair = new List<string>(wholeList.Skip(i).Take(2).ToList());
                    questions.Add(questionPair.Select(int.Parse).ToList());
                }
                    return questions;
            } 
        }
    }
}
