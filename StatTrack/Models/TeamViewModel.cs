using System.Collections.Generic;

namespace StatTrack.Models
{
    public class TeamViewModel
    {
        public IEnumerable<TeamModel> TModels { get; set; }
        public TeamModel TModel { get; set; }
    }
}