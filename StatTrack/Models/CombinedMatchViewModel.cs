using System.Collections.Generic;

namespace StatTrack.Models
{
    public class CombinedMatchViewModel
    {
        public IEnumerable<MatchViewModel> StatsModel { get; set; }
        public IEnumerable<GameDataModel> GameModel { get; set; }
    }
}