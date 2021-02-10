using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class UnisonGame : NewGame, IGame
    {
        public Result Result { get; set; }
        public List<int> Question
        {
            get
            {
                var question = Result.Questions.Split(',').Select(int.Parse).ToList();
                return question;
            }
        }


        public override ChromaticFretboard ChromaticFretboard
        {
            get
            {
                var fretboard = new ChromaticFretboard()
                {
                    Tuning = Result.Tuning
                };
                return fretboard;
            }
        }


        public List<List<int>> Answers
        {
            get
            {
                if (Result.Answers is not null)
                {
                    var answers = new List<List<int>>();
                    var wholeList = Result.Answers.Split(',').ToList();
                    for (int i = 0; i < wholeList.Count(); i += 2)
                    {
                        var answerPair = new List<string>(wholeList.Skip(i).Take(2).ToList());
                        answers.Add(answerPair.Select(int.Parse).ToList());
                    }
                    return answers;
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
                if (Result.Answers is not null)
                {
                    var outcomes = new List<bool>();
                    for (int i = 0; i < Answers.Count(); i++)
                    {
                        var correctAnswer = ChromaticFretboard.Fretboard[Question[0]][Question[1]];
                        var answer = ChromaticFretboard.Fretboard[Answers[i][0]][Answers[i][1]];
                        if (answer == correctAnswer)
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
    }
}
