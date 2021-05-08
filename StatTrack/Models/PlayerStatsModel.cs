using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class PlayerStatsModel
    {
        public int PlayerId { get; set; }
        public int GoalAttempts { get; set; }
        public int Goals { get; set; }
        public int Mins2 { get; set; }
        public int Yellowcards { get; set; }
        public int Redcards { get; set; }
        public int KampId { get; set; }
    }
}
