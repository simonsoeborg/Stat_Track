using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    class TeamModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ClubModel Club { get; set; }
        public string Year { get; set; }
        public string League { get; set; }
        public List<PlayerModel> PlayerList { get; set; }

        public int StartYear { get; set; }
        public int EndYear { get; set; }

    }
}
