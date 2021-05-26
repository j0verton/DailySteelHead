using System;
using Xunit;
using SteelDaily.Models;
using SteelDaily.Models.ViewModel;

namespace SteelDaily.Tests
{
    public class TuningModelTest
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
            var ChromFretboard = new ChromaticFretboard()
            {
                Tuning = TestTuning
            };


            string stringTen = TestTuning.Notes.Split(',', ' ')[0];
            //Assert.Equal("B", stringTen);
            Assert.Equal(stringTen, ChromFretboard.Fretboard[0][0].ToString());


        }
        [Fact]
        public void Computed_Fretboard_At_One_One_Should_Be_Zero_One_Plus_One()
        {
            var testTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };
            var chromFretboard = new ChromaticFretboard()
            {
                Tuning = testTuning
            };

            string stringTen = testTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("Eb", chromFretboard.Fretboard[1][1].ToString());


        }
        [Fact]
        public void Computed_Fretboard_At_One_Zero_Should_Be_Zero_Zero_Plus_One()
        {
            //the tests turning the corner from 12 to 1 or B to C
            var testTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };
            var chromFretboard = new ChromaticFretboard()
            {
                Tuning = testTuning
            };

            string stringTen = testTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("C", chromFretboard.Fretboard[1][0].ToString());
        }
        [Fact]
        public void Computed_Fretboard_At_One_Zero_Should_Be_Thirteen_Zero()
        {
            //the tests turning the corner from 12 to 1 or B to C
            var testTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };
            var chromFretboard = new ChromaticFretboard()
            {
                Tuning = testTuning
            };

            string stringTen = testTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("C", chromFretboard.Fretboard[13][0].ToString());
        }
        [Fact]
        public void Computed_Fretboard_At_One_Nine_Should_Be_Thirteen_Nine()
        {
            //the tests turning the corner from 12 to 1 or B to C
            var testTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };
            var chromFretboard = new ChromaticFretboard()
            {
                Tuning = testTuning
            };
            string stringTen = testTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("E", chromFretboard.Fretboard[13][8].ToString());
        }
    }
}
