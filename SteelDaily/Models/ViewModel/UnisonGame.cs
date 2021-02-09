using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class UnisonGame : NewGame
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


        public List<bool> Outcomes 
        {
            get { 
                if(Result.Answers is not null)
                {
                    var outcomes = new List<bool>();
                    var answerList = Result.Answers.Split(',').ToList();
                    for (int i = 0; i < answerList.Count(); i++)
                    {
                        var correctAnswer = ChromaticFretboard[Question[0]][Question[1]];
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
    }
}
