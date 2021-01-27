using System;
using Xunit;
using SteelDaily.Models;

namespace SteelDaily.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Computed_Fretboard_At_Zero_Should_Match_Notes()
        {
            var TestTuning = new Tuning()
            { 
                Id = 1, 
                Name = "E9", 
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb" 
            };
            
            string stringTen = TestTuning.Notes.Split(',', ' ')[0];
            //Assert.Equal("B", stringTen);
            Assert.Equal(stringTen, TestTuning.Fretboard[0][0].ToString());


        }
        [Fact]
        public void Computed_Fretboard_At_One_One_Should_Be_Zero_One_Plus_One()
        {
            var TestTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };

            string stringTen = TestTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("Eb", TestTuning.Fretboard[1][1].ToString());


        }
        [Fact]
        public void Computed_Fretboard_At_One_Zero_Should_Be_Zero_Zero_Plus_One()
        {
            //the tests turning the corner from 12 to 1 or B to C
            var TestTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };

            string stringTen = TestTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("C", TestTuning.Fretboard[1][0].ToString());


        }
    }
}
