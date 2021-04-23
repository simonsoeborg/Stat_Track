using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class TeamPlayersViewModel
    {
        public IEnumerable<TeamPlayerModel> TModels { get; set; }
        public TeamPlayerModel TModel { get; set; }

    }
}
