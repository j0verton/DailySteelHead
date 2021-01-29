using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models.ViewModel
{
    public class InProcessGame
    {
        public List<int> QuestionNumbers { get; set; }

        public Result Result { get; set; }
    }
}
