using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    [Table("result")]
    public class Result
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("userprofileid")]
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        [Column("gameid")]
        public int GameId { get; set; }
        public Game Game {get;set;}
        [MaxLength(5)]
        [Column("root")]
        public string Root  { get; set; }
        [Column("tuningid")]
        public int TuningId { get; set; }
        public Tuning Tuning { get; set; }
        [Column("questions")]
        public string Questions { get; set; }
        [Column("answers")]
        public string Answers { get; set; }
        [Column("public")]
        public bool Public { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("complete")]
        public bool Complete { get; set; }

    }
}
