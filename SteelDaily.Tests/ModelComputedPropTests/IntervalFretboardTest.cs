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
        [Fact]
        public void Key_Of_E_Inteval_Fretboard_At_Zero_Nine_Return_The_Correct_Intervals()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "E",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
                    },
                }
            };
            //Assert.Equal("B", stringTen);
            Assert.Equal("Five", FretboardTest.IntFretboard[0][9].ToString());
        }
        [Fact]

        public void Key_Of_E_Inteval_Fretboard_At_Zero_Eight_Return_The_Correct_Intervals()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "E",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
                    },
                }
            };
            //Assert.Equal("B", stringTen);
            Assert.Equal("FlatSeven", FretboardTest.IntFretboard[0][8].ToString());
        }
        [Fact]

        public void Key_Of_E_Inteval_Fretboard_At_Zero_Seven_Return_The_Correct_Intervals()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "E",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
                    },
                }
            };
            //Assert.Equal("B", stringTen);
            Assert.Equal("One", FretboardTest.IntFretboard[0][7].ToString());
        }

        [Fact]
        public void Key_Of_C_Inteval_Fretboard_At_Zero_Nine_Return_The_Correct_Intervals()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "C",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
                    },
                }
            };
            //Assert.Equal("B", stringTen);
            Assert.Equal("Seven", FretboardTest.IntFretboard[0][9].ToString());
        }
        [Fact]
        public void Key_Of_C_Inteval_Fretboard_At_Zero_Eight_Return_The_Correct_Intervals()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "C",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
                    },
                }
            };
            //Assert.Equal("B", stringTen);
            Assert.Equal("Two", FretboardTest.IntFretboard[0][8].ToString());
        }
        [Fact]

        public void Key_Of_C_Inteval_Fretboard_At_Zero_Seven_Return_The_Correct_Intervals()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "C",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
                    },
                }
            };
            //Assert.Equal("B", stringTen);
            Assert.Equal("Three", FretboardTest.IntFretboard[0][7].ToString());
        }

        [Fact]

        public void Key_Of_B_Inteval_Fretboard_At_Zero_Eight_Return_The_Correct_Intervals()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "B",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
                    },
                }
            };
            //Assert.Equal("B", stringTen);
            Assert.Equal("FlatThree", FretboardTest.IntFretboard[0][8].ToString());
        }
        [Fact]
        public void Key_Of_Bb_Inteval_Fretboard_At_Fret_Six_Should_Return_The_Correct_Array()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "Bb",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
                    },
                }
            };
            var expected = new List<string>() 
            { 
                "Two", "Seven", "Three", "One", "Five", "Three", "Two", "One", "FlatSeven", "Five" 
            };

            Assert.Equal(expected, FretboardTest.IntFretboard[6]);
        }
        [Fact]
        public void Key_Of_Bb_Inteval_Fretboard_At_Fret_One_Should_Return_The_Correct_Array()
        {
            var FretboardTest = new IntervalFretboard()
            {
                Key = "B",
                ChromaticFretboard = new ChromaticFretboard()
                {
                    Tuning = new Tuning()
                    {
                        Id = 1,
                        Name = "E9",
                        Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
                    },
                }
            };
            var expected = new List<string>()
            {
                "Two", "Seven", "Three", "One", "Five", "Three", "Two", "One", "FlatSeven", "Five"
            };

            Assert.Equal(expected, FretboardTest.IntFretboard[7]);
        }
    }

}
