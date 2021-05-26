using SteelDaily.Models;
using SteelDaily.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SteelDaily.Tests.ModelComputedPropTests
{
    public class UnisonGameTests
    {
        [Fact]
        public void Correct_Answer_Should_Create_Correct_Outcome()
        {
            var TestTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
            };
            var Result1 = new Result()
            {
                Id = 1,
                TuningId = 1,
                Tuning = TestTuning,
                Questions = "8,7",
                Answers = "6,6,6,5"
            };
//true, false

            var Game = new UnisonGame()
            {
                Result = Result1
            };

            Assert.True(Game.Outcomes[0]);
            //Assert.True(Game.Outcomes[1]);
            //Assert.True(Game.Outcomes[2]);
            //Assert.True(Game.Outcomes[3]);

        }
    }
}
