using System.Collections.Generic;

namespace StatTrack.Models
{
    public class TeamPlayersViewModel
    {
        public IEnumerable<TeamPlayerModel> TModels { get; set; }
        public TeamPlayerModel TModel { get; set; }
    }
}