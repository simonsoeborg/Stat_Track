using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class MasterModel
    {
        public TeamModel TeamModel { get; set; }
        public ClubModel ClubModel { get; set; }
        public TeamPlayerModel TeamPlayerModel { get; set; }
    }
}
