using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class CombinedMatchViewModel
    {
        public IEnumerable<MatchViewModel> StatsModel { get; set; }
        public IEnumerable<GameDataModel> GameModel { get; set; }
    }
}
