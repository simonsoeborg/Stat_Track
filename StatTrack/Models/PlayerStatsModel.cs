using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class PlayerStatsModel
    {
        public int PlayerId { get; set; }
        public int Attempts { get; set; }
        public int Goals { get; set; }
        public int KeeperSaves { get; set; }
        public int Assists { get; set; }
        public int Mins2 { get; set; }
        public int Yellowcards { get; set; }
        public int Redcards { get; set; }
        public string tidspunkt { get; set; }
        public int KampId { get; set; }
        public string KampDato { get; set; }

    }
}
