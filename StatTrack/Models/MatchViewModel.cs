using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class MatchViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string EventType { get; set; }
        public string Modstander { get; set; }
        public string KampDato { get; set; }
    }
}
