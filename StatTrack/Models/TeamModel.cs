using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class TeamModel
    {
        public string Name { get; set; }
        public ClubModel Club { get; set; }
        public string Year { get; set; }
        public string League { get; set; }
        public List<PlayerModel> PlayerList { get; set; }
    }
}
