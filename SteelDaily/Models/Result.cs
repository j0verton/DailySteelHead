using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    public class Result
    {
        public int Id  {get; set;}
        public int UserId  {get; set;}
        public int GameId  { get; set; }
        public string Key  { get; set; }
        public int ScaleId { get; set; }
        public Scale Scale { get; set; }
        public int TuningId { get; set; }
        public Tuning Tuning { get; set; }
        public List<List<int>> Questions { get; set; }
        public List<bool> Outcomes { get; set; }
        public bool Public { get; set; }
        public DateTime Date { get; set; }

        //could refactor to compute completion at 10 answers, 
        //would then need to also change gamecontroller answer method
        public bool Complete { get; set; }
    }
}
