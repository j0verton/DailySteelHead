using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    public class MusicTheory
    {
        [Key]
        public int Id { get; set; }

        public enum ChromaticScale
        {
            C = 1, 
            Db = 2, 
            D = 3, 
            Eb = 4, 
            E = 5, 
            F = 6, 
            Gb = 7, 
            G = 8, 
            Ab = 9, 
            A = 10, 
            Bb = 11, 
            B = 12
        }
        public enum Intervals
        {
            [Description("1")]
            One = 1,
            [Description("b2")]
            FlatTwo = 2,
            [Description("2")]
            Two = 3,
            [Description("b3")]
            FlatThree = 4,
            [Description("3")]
            Three = 5,
            [Description("4")]
            Four = 6,
            [Description("b5")]
            FlatFive = 7,
            [Description("5")]
            Five = 8,
            [Description("b6")]
            FlatSix = 9,
            [Description("6")]
            Six = 10,
            [Description("b7")]
            FlatSeven = 11,
            [Description("7")]
            Seven = 12
        }

        //public static int CSToInt(ChromaticScale enum)   
        //{
        //    return Convert.ToInt32(enum)
        //}
        //public string GetDescription(this Enum value)
        //{
        //    return ((DescriptionAttribute)Attribute.GetCustomAttribute(
        //        value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
        //            .Single(x => x.GetValue(null).Equals(value)),
        //        typeof(DescriptionAttribute)))?.Description ?? value.ToString();
        //}

        //public Dictionary<int, string> Intervals
        //{ get; 
        //    set
        //    {
        //        1 = "1", 2 = "b2", 3 = "2", 4 = "b3", 5 = "3", 6 = "4", 7 = "b5", 8 = "5", 9 = "b6", 10 = "6", 11 = "b7", 12 = "7"
        //    };
        //}

    }
}
