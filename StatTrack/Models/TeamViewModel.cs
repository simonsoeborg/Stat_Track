using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class TeamViewModel 
    { 
        public IEnumerable<TeamModel> TModels { get; set; }
        public TeamModel TModel { get; set; }
    }
}
