using System;
using Xunit;
using SteelDaily.Models;
using SteelDaily.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace SteelDaily.Tests
{
    public class IntervalFretboardTest
    {
        public IntervalFretboardTest()
        {
            var foo = 1;
        }
        [Fact]
        public void Inteval_Fretboard_At_Zero_Should_Match_Tuning_Fretboard()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "D",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
                    },
                }
            };
            //Assert.Equal("B", stringTen);
            Assert.Equal("One", FretboardTest.IntFretboard[0][1].ToString());
        }

        [Fact]
        public void Inteval_Fretboard_At_Twelve_Should_Match_Tuning_Fretboard()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "D",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
                    },
                }
            };
            //Assert.Equal("B", stringTen);
            Assert.Equal("FlatFive", FretboardTest.IntFretboard[0][4].ToString());
        }
    }

}
