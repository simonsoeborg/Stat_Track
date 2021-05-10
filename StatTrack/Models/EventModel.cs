using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatTrack.Models
{
    public class EventModel
    {
        public string EventType { get; set; }
        public int PlayerId { get; set; }
        public string Time { get; set; }
        public int KampId { get; set; }
    }
}
