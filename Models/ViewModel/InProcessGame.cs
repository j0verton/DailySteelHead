using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class InProcessGame : NewGame, IGame
    {

        public Result Result { get; set; }
        public IntervalFretboard Fretboard
        {
            get {
                var fretboard = new IntervalFretboard()
                {
                    Key = Result.Root,
                    ChromaticFretboard = new ChromaticFretboard()
                    {
                        Tuning = Result.Tuning
                    }

                };
                return fretboard;
            }
        }
        public List<string> AnswerList
        {
            get
            {
                if (Result.Answers != null)
                {
                    return Result.Answers.Split(',').ToList();
                }
                else
                {
                    return null;
                }


            }
        }
        public List<bool> Outcomes
        {
            get
            {
                if (Result.Answers != null)
                {
                    var outcomes = new List<bool>();
                    var answerList = Result.Answers.Split(',').ToList();
                    for (int i = 0; i < answerList.Count; i++)
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
                else
                {
                    return null;
                }

            }
        }
        public List<string> CorrectAnswerList
        {
            get
            {
                var correctAnswerList = new List<string>();
                if (Result.Answers != null)
                {
                    for (int i = 0; i < Questions.Count(); i++)
                    {
                        var question = Questions[i];
                        var correctAnswer = Fretboard.IntFretboard[question[0]][question[1]];
                        correctAnswerList.Add(correctAnswer);
                    }
                    return correctAnswerList;
                }
                return null;
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
