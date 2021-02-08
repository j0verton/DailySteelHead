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

    }
}
