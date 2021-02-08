using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int GameId { get; set; }
        public Game Game {get;set;}
        [MaxLength(5)]
        public string Key  { get; set; }
        public int ScaleId { get; set; }
        public Scale Scale { get; set; }
        public int TuningId { get; set; }
        public Tuning Tuning { get; set; }
        public string Questions { get; set; }
        public string Answers { get; set; }
        public bool Public { get; set; }
        public DateTime Date { get; set; }
        public bool Complete { get; set; }

    }
}
